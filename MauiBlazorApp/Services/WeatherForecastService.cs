using AutoMapper;
using MauiBlazorApp.Data;
using MauiBlazorApp.Helpers;
using MauiBlazorApp.Interfaces;
using MauiBlazorApp.Models;
using MauiBlazorApp.Services.Shared;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MauiBlazorApp.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        //public Task InitializeWeatherAsync(string stringToService, HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        public WeatherForecastService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        //public async void InitializeAsync(HttpClient httpClient, IMapper mapper)
        //{
        //     _httpClient = httpClient;
        //    _mapper = mapper;
        //}

        public async Task<WeatherForecast[]> GetAllWithPositiveTemperatureAsync()
        {
            WeatherForecast[] responseWeatherForecast = null;

            try
            {
                responseWeatherForecast = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");

                responseWeatherForecast = responseWeatherForecast.Where(x => x.TemperatureC >= 0).ToArray();
            }
            catch (Exception e)
            {

                throw;
            }


            return responseWeatherForecast;
        }

        public async Task<WeatherForecast[]> GetAllAsync()
         {
              WeatherForecast[] responseWeatherForecast = null; 

            try
            {

                //var path = String.Concat(MauiProgram.rootPath, "/sample-data/weather.json");


                //string[] files = Directory.GetFiles("/data/user/0/com.companyname.mauiblazorapp/", "*.*", SearchOption.AllDirectories);

                //foreach(string file in files)
                //{
                //    var fileName = Path.GetFileName(file);
                //    if(fileName.Contains("weather"))
                //    {
                //        var x = Path.GetDirectoryName(file);
                //    }
                //}

                //var jsonText = File.ReadAllText(path);

                //var data = JsonConvert.DeserializeObject<WeatherForecast[]>(jsonText);

                var data = await WeatherForecastFake.GetForecastAsync(DateTime.Now);

                return data;
            }
            catch (Exception e)
            {

                throw;
            }
            

             return responseWeatherForecast;
        }

        public async Task<ResponseService> Update<T>(T data)
        {
            try
            {
                var tranformedObject = Transform.KeyValListToObject(data as List<KeyVal<string, string>>);

                WeatherForecast update = _mapper.Map<WeatherForecast>(tranformedObject);

                await _httpClient.PutAsJsonAsync<WeatherForecast>("sample-data/weather.json", update);
            }
            catch (Exception e)
            {
                throw;
            }


            return null;
        }

    }
}
