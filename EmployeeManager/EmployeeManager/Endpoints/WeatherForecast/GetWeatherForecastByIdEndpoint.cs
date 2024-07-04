using EmployeeManager.WeatherForecasts;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class GetWeatherForecastByIdEndpoint
{
    public static IEndpointRouteBuilder MapGetWeatherForecastByIdEndpoint(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGet("/weatherforecast/{id}", GetWeatherForecastById);

        return builder;
    }

    private static WeatherForecasts.WeatherForecast GetWeatherForecastById(Guid id)
    {
        var forecast = WeatherForecastsStore.Store.FirstOrDefault(x => x.Id == id);

        return forecast;
    }
}
