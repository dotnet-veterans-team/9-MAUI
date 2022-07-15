using MauiBlazorApp.Models;

namespace MauiBlazorApp.Interfaces
{
    public interface IWeatherForecastService : IService
    {
        Task<WeatherForecast[]> GetAllWithPositiveTemperatureAsync();
    }
}
