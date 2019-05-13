using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Converters
{
    public static class InvoiceLineConverter
    {
        public static InvoiceLineViewModel Convert(InvoiceLine invoiceLine)
        {
            var invoiceLineViewModel = new InvoiceLineViewModel
            {
                InvoiceLineId = invoiceLine.InvoiceLineId,
                InvoiceId = invoiceLine.InvoiceId,
                TrackId = invoiceLine.TrackId,
                UnitPrice = invoiceLine.UnitPrice,
                Quantity = invoiceLine.Quantity
            };

            return invoiceLineViewModel;
        }

        public static List<InvoiceLineViewModel> ConvertList(IEnumerable<InvoiceLine> invoiceLines)
        {
            return invoiceLines.Select(i =>
                {
                    var model = new InvoiceLineViewModel
                    {
                        InvoiceLineId = i.InvoiceLineId,
                        InvoiceId = i.InvoiceId,
                        TrackId = i.TrackId,
                        UnitPrice = i.UnitPrice,
                        Quantity = i.Quantity
                    };
                    return model;
                })
                .ToList();
        }
    }
}