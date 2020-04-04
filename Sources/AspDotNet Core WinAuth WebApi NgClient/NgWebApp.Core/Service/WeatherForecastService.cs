using System;
using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Interface;
using $safeprojectname$.Data.Model;

namespace $safeprojectname$.Service
{
    public class WeatherForecastService: IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public IEnumerable<WeatherForecast> getForecasts(int forDays)
        {
            var rng = new Random();
            return Enumerable.Range(1, forDays).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}
