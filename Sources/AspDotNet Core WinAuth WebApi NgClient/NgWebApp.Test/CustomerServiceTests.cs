using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using $ext_safeprojectname$.Core.Data;
using $ext_safeprojectname$.Core.Service;

namespace $safeprojectname$
{
    [TestClass]
    public class CustomerServiceTests
    {

        [TestMethod]
        public void ShouldGetAllCustomers()
        {
            var loggerMock = new Mock<ILogger<CustomerService>>();
            var dataService = new DataService("Data Source=..\\..\\..\\..\\$ext_safeprojectname$.Web\\Data\\nwind.sqlite");
            var cs = new CustomerService(loggerMock.Object, dataService);
            var result = cs.getAllCustomers();

            Assert.IsTrue(result.Any());
        }
    }
}
