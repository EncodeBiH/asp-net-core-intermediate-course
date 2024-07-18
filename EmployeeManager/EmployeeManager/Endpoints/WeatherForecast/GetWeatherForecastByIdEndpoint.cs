using EmployeeManager.Database;
using EmployeeManager.WeatherForecasts;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class GetWeatherForecastByIdEndpoint
{
    public static IEndpointRouteBuilder MapGetWeatherForecastByIdEndpoint(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGet("/api/weatherforecast/{id}", GetWeatherForecastById);

        return builder;
    }

    private static WeatherForecasts.WeatherForecast GetWeatherForecastById(Guid id, ApplicationDbContext context)
    {
        var forecast = context.WeatherForecasts.FirstOrDefault(x => x.Id == id);

        return forecast;
    }
}
