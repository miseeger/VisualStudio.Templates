using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using $ext_safeprojectname$.Core.Data.Entities;
using $ext_safeprojectname$.Core.Interface;


namespace NgWebApp2.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/weatherforecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [Produces(typeof(IEnumerable<WeatherForecast>))]
        public async Task<IActionResult> Get()
        {
            var fc = await _weatherForecastService.getForecastsAsync(20);
            _logger.LogInformation($"Forecast was generated.");
            return Ok(fc);
        }
    }
}
