using System.Collections.Generic;
using System.Threading.Tasks;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Interface
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> getForecastsAsync(int forDays);
    }
}
