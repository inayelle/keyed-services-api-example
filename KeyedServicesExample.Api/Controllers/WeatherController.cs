using KeyedServicesExample.Api.Providers;
using Microsoft.AspNetCore.Mvc;

namespace KeyedServicesExample.Api.Controllers;

[ApiController]
[Route("weather")]
public sealed class WeatherController : ControllerBase
{
    private readonly IWeatherProvider _defaultWeatherProvider;

    public WeatherController([FromKeyedServices(WeatherProvider.AccuWeather)] IWeatherProvider defaultWeatherProvider)
    {
        _defaultWeatherProvider = defaultWeatherProvider;
    }

    [HttpGet]
    public object GetWeather(
        [FromQuery] string city,
        [FromQuery] WeatherProvider? weatherProvider = null
    )
    {
        var provider = weatherProvider.HasValue
            ? HttpContext.RequestServices.GetRequiredKeyedService<IWeatherProvider>(weatherProvider.Value)
            : _defaultWeatherProvider;

        return new
        {
            City = city,
            Weather = provider.GetWeatherForCity(city)
        };
    }
}