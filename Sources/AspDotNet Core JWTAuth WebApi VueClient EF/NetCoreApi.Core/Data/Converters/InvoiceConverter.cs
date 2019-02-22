using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Converters
{
    public static class InvoiceConverter
    {
        public static InvoiceViewModel Convert(Invoice invoice)
        {
            var invoiceViewModel = new InvoiceViewModel
            {
                InvoiceId = invoice.InvoiceId,
                CustomerId = invoice.CustomerId,
                InvoiceDate = invoice.InvoiceDate,
                BillingAddress = invoice.BillingAddress,
                BillingCity = invoice.BillingCity,
                BillingState = invoice.BillingState,
                BillingCountry = invoice.BillingCountry,
                BillingPostalCode = invoice.BillingPostalCode,
                Total = invoice.Total
            };

            return invoiceViewModel;
        }

        public static List<InvoiceViewModel> ConvertList(IEnumerable<Invoice> invoices)
        {
            return invoices.Select(i =>
                {
                    var model = new InvoiceViewModel
                    {
                        InvoiceId = i.InvoiceId,
                        CustomerId = i.CustomerId,
                        InvoiceDate = i.InvoiceDate,
                        BillingAddress = i.BillingAddress,
                        BillingCity = i.BillingCity,
                        BillingState = i.BillingState,
                        BillingCountry = i.BillingCountry,
                        BillingPostalCode = i.BillingPostalCode,
                        Total = i.Total
                    };
                    return model;
                })
                .ToList();
        }
    }
}