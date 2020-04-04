using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using $ext_safeprojectname$.Core.Interface;
using $ext_safeprojectname$.Core.Data.Model;

namespace $safeprojectname$.Controllers
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var fc = _weatherForecastService.getForecasts(20);
            _logger.LogInformation($"Forecast was generated.");
            return fc;
        }
    }
}
