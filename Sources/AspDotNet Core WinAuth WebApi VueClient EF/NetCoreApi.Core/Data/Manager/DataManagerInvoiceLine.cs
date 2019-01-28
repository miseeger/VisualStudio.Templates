using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using $safeprojectname$.Data.Converters;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Manager
{
    public partial class DataManager : IDataManager
    {
        public async Task<List<InvoiceLineViewModel>> GetAllInvoiceLineAsync(
            CancellationToken ct = default(CancellationToken))
        {
            var invoiceLines = InvoiceLineConverter.ConvertList(await _invoiceLineRepository.GetAllAsync(ct));
            return invoiceLines;
        }

        public async Task<InvoiceLineViewModel> GetInvoiceLineByIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var invoiceLineViewModel = InvoiceLineConverter.Convert(await _invoiceLineRepository.GetByIdAsync(id, ct));
            invoiceLineViewModel.Track = await GetTrackByIdAsync(invoiceLineViewModel.TrackId, ct);
            invoiceLineViewModel.Invoice = await GetInvoiceByIdAsync(invoiceLineViewModel.InvoiceId, ct);
            invoiceLineViewModel.TrackName = invoiceLineViewModel.Track.Name;
            return invoiceLineViewModel;
        }

        public async Task<List<InvoiceLineViewModel>> GetInvoiceLineByInvoiceIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var invoiceLines = await _invoiceLineRepository.GetByInvoiceIdAsync(id, ct);
            return InvoiceLineConverter.ConvertList(invoiceLines).ToList();
        }

        public async Task<List<InvoiceLineViewModel>> GetInvoiceLineByTrackIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var invoiceLines = await _invoiceLineRepository.GetByTrackIdAsync(id, ct);
            return InvoiceLineConverter.ConvertList(invoiceLines).ToList();
        }

        public async Task<InvoiceLineViewModel> AddInvoiceLineAsync(InvoiceLineViewModel newInvoiceLineViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var invoiceLine = new InvoiceLine
            {
                InvoiceId = newInvoiceLineViewModel.InvoiceId,
                TrackId = newInvoiceLineViewModel.TrackId,
                UnitPrice = newInvoiceLineViewModel.UnitPrice,
                Quantity = newInvoiceLineViewModel.Quantity
            };

            invoiceLine = await _invoiceLineRepository.AddAsync(invoiceLine, ct);
            newInvoiceLineViewModel.InvoiceLineId = invoiceLine.InvoiceLineId;
            return newInvoiceLineViewModel;
        }

        public async Task<bool> UpdateInvoiceLineAsync(InvoiceLineViewModel invoiceLineViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var invoiceLine = await _invoiceLineRepository.GetByIdAsync(invoiceLineViewModel.InvoiceId, ct);

            if (invoiceLine == null) return false;
            invoiceLine.InvoiceLineId = invoiceLineViewModel.InvoiceLineId;
            invoiceLine.InvoiceId = invoiceLineViewModel.InvoiceId;
            invoiceLine.TrackId = invoiceLineViewModel.TrackId;
            invoiceLine.UnitPrice = invoiceLineViewModel.UnitPrice;
            invoiceLine.Quantity = invoiceLineViewModel.Quantity;

            return await _invoiceLineRepository.UpdateAsync(invoiceLine, ct);
        }

        public async Task<bool> DeleteInvoiceLineAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _invoiceLineRepository.DeleteAsync(id, ct);
        }
    }
}