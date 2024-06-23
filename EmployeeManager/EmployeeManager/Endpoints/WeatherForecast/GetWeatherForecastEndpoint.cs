using EmployeeManager.WeatherForecasts;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class GetWeatherForecastEndpoint
{
    public static IEndpointRouteBuilder MapGetWeatherForecastEndpoint(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGet("/weatherforecast", GetWeatherForecast)
            .WithTags("Weather Forecast")
            .WithOpenApi();

        return builder;
    }

    private static List<WeatherForecasts.WeatherForecast> GetWeatherForecast()
    {
        return WeatherForecastsStore.Store.ToList();
    }
}