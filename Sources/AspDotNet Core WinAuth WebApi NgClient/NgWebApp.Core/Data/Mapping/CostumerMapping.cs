using $safeprojectname$.Data.Model;
using NPoco.FluentMappings;

namespace $safeprojectname$.Data.Mapping
{
    public class CustomerMapping : Map<Customer>
    {
        public CustomerMapping()
        {
            TableName("Customer");
            PrimaryKey(x => x.Id);

            Columns(x =>
            {
                x.Column(y => y.Id);
                x.Column(y => y.CompanyName);
                x.Column(y => y.ContactName);
                x.Column(y => y.ContactTitle);
                x.Column(y => y.Address);
                x.Column(y => y.Region);
                x.Column(y => y.PostalCode);
                x.Column(y => y.Country);
                x.Column(y => y.Phone);
                x.Column(y => y.Fax);
            });
        }
    }
}
