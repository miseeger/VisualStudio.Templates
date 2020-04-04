using System.Collections.Generic;
using $safeprojectname$.Data.Model;

namespace $safeprojectname$.Interface
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> getForecasts(int forDays);
    }
}
