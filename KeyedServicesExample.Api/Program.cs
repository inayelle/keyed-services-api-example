using KeyedServicesExample.Api.Providers;

var builder = WebApplication.CreateBuilder();

builder
   .Services
   .AddSwaggerGen()
   .AddControllers();

builder
   .Services
   .AddKeyedScoped<IWeatherProvider, OpenWeatherMapWeatherProvider>(WeatherProvider.OpenWeatherMap)
   .AddKeyedScoped<IWeatherProvider, AccuWeatherWeatherProvider>(WeatherProvider.AccuWeather);

var app = builder.Build();

app
   .UseSwagger()
   .UseSwaggerUI();

app.MapControllers();

await app.RunAsync();