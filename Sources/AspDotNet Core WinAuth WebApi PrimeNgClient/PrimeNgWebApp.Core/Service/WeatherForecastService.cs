using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Interface;

namespace $safeprojectname$.Service
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public async Task<IEnumerable<WeatherForecast>> getForecastsAsync(int forDays)
        {
            var rng = new Random();
            IEnumerable<WeatherForecast> result = new List<WeatherForecast>();

            await Task.Run(() =>
            {
                result = Enumerable
                    .Range(1, forDays)
                    .Select(index => new WeatherForecast
                        {
                            Date = DateTime.Now.AddDays(index),
                            TemperatureC = rng.Next(-20, 55),
                            Summary = Summaries[rng.Next(Summaries.Length)]
                        }
                    )
                    .ToList();
            });

            return result;
        }
    }
}
