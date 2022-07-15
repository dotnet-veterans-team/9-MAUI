using AutoMapper;
using Blazored.Modal;
using MauiBlazorApp.Interfaces;
using MauiBlazorApp.Services;

namespace MauiBlazorApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        //builder.Services.AddSingleton<WeatherForecastService>();

        builder.Services.AddBlazoredModal();

        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            //rootPath = "";

        }

        var path = "http://localhost/";

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(path) });

        var configuration = new MapperConfiguration(cfg => { });
        var mapper = configuration.CreateMapper();

        builder.Services.AddSingleton(mapper);

        builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();


        //var host = builder.Build();

        //var weatherService = host.Services.GetRequiredService<IWeatherForecastService>();

        //weatherService.InitializeAsync(httpClient, mapper);

        //host.RunAsync();

        return builder.Build();
	}
}
