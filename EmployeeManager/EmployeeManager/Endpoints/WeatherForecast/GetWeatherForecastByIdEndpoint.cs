using EmployeeManager.WeatherForecasts;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class GetWeatherForecastByIdEndpoint
{
    public static IEndpointRouteBuilder MapGetWeatherForecastByIdEndpoint(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGet("/weatherforecast/{id}", GetWeatherForecastById)
            .WithTags("Weather Forecast")
            .WithOpenApi();

        return builder;
    }

    private static WeatherForecasts.WeatherForecast GetWeatherForecastById(Guid id)
    {
        var forecast = WeatherForecastsStore.Store.FirstOrDefault(x => x.Id == id);

        return forecast;
    }
}
