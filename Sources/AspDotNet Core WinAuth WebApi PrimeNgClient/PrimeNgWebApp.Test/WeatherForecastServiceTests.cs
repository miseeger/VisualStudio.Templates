using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using $ext_safeprojectname$.Core.Service;

namespace $safeprojectname$
{
    [TestClass]
    public class WeatherForecastServiceTests
    {

        [TestMethod]
        public void ShuldCrate5Forecasts()
        {
            var fs = new WeatherForecastService();
            Assert.AreEqual(5, fs.getForecastsAsync(5).Result.Count());
        }
    }
}
