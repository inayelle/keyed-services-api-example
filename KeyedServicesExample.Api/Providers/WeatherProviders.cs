namespace KeyedServicesExample.Api.Providers;

public enum WeatherProvider
{
    AccuWeather = 1,
    OpenWeatherMap = 2,
}

public interface IWeatherProvider
{
    string GetWeatherForCity(string city);
}

internal sealed class AccuWeatherWeatherProvider : IWeatherProvider
{
    public string GetWeatherForCity(string city) => "AccuWeather";
}

internal sealed class OpenWeatherMapWeatherProvider : IWeatherProvider
{
    public string GetWeatherForCity(string city) => "OpenWeather";
}
