using EmployeeManager.WeatherForecasts;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class GetWeatherForecastEndpoint
{
    public static IEndpointRouteBuilder MapGetWeatherForecastEndpoint(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGet("/api/weatherforecast", GetWeatherForecast)
            .RequireAuthorization(x => x.RequireAuthenticatedUser());

        return builder;
    }

    private static List<WeatherForecasts.WeatherForecast> GetWeatherForecast()
    {
        return WeatherForecastsStore.Store.ToList();
    }
}