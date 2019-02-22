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
        public async Task<List<InvoiceViewModel>> GetAllInvoiceAsync(CancellationToken ct = default(CancellationToken))
        {
            var invoices = InvoiceConverter.ConvertList(await _invoiceRepository.GetAllAsync(ct));
            return invoices;
        }

        public async Task<InvoiceViewModel> GetInvoiceByIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var invoiceViewModel = InvoiceConverter.Convert(await _invoiceRepository.GetByIdAsync(id, ct));
            invoiceViewModel.Customer = await GetCustomerByIdAsync(invoiceViewModel.CustomerId, ct);
            invoiceViewModel.InvoiceLines = await GetInvoiceLineByInvoiceIdAsync(invoiceViewModel.InvoiceId, ct);
            invoiceViewModel.CustomerName =
                $"{invoiceViewModel.Customer.LastName}, {invoiceViewModel.Customer.FirstName}";
            return invoiceViewModel;
        }

        public async Task<List<InvoiceViewModel>> GetInvoiceByCustomerIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var invoices = await _invoiceRepository.GetByCustomerIdAsync(id, ct);
            return InvoiceConverter.ConvertList(invoices).ToList();
        }

        public async Task<InvoiceViewModel> AddInvoiceAsync(InvoiceViewModel newInvoiceViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var invoice = new Invoice
            {
                CustomerId = newInvoiceViewModel.CustomerId,
                InvoiceDate = newInvoiceViewModel.InvoiceDate,
                BillingAddress = newInvoiceViewModel.BillingAddress,
                BillingCity = newInvoiceViewModel.BillingCity,
                BillingState = newInvoiceViewModel.BillingState,
                BillingCountry = newInvoiceViewModel.BillingCountry,
                BillingPostalCode = newInvoiceViewModel.BillingPostalCode,
                Total = newInvoiceViewModel.Total
            };

            invoice = await _invoiceRepository.AddAsync(invoice, ct);
            newInvoiceViewModel.InvoiceId = invoice.InvoiceId;
            return newInvoiceViewModel;
        }

        public async Task<bool> UpdateInvoiceAsync(InvoiceViewModel invoiceViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceViewModel.InvoiceId, ct);

            if (invoice == null) return false;
            invoice.InvoiceId = invoiceViewModel.InvoiceId;
            invoice.CustomerId = invoiceViewModel.CustomerId;
            invoice.InvoiceDate = invoiceViewModel.InvoiceDate;
            invoice.BillingAddress = invoiceViewModel.BillingAddress;
            invoice.BillingCity = invoiceViewModel.BillingCity;
            invoice.BillingState = invoiceViewModel.BillingState;
            invoice.BillingCountry = invoiceViewModel.BillingCountry;
            invoice.BillingPostalCode = invoiceViewModel.BillingPostalCode;
            invoice.Total = invoiceViewModel.Total;

            return await _invoiceRepository.UpdateAsync(invoice, ct);
        }

        public async Task<bool> DeleteInvoiceAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _invoiceRepository.DeleteAsync(id, ct);
        }
    }
}