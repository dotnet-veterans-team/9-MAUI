using AutoMapper;
using MauiBlazorApp.Models;
using MauiBlazorApp.Services.Shared;

namespace MauiBlazorApp.Interfaces
{
    public interface IService
    {
        Task<WeatherForecast[]> GetAllAsync();

        Task<ResponseService> Update<T>(T data);
    }
}
