using EmployeeManager.WeatherForecasts;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class DeleteWeatherForecastEndpoint
{
    public static IEndpointRouteBuilder MapDeleteWeatherForecastEndpoint(this IEndpointRouteBuilder builder)
    {
        builder
            .MapDelete("/api/weatherforecast/{id}", DeleteWeatherForecast);

        return builder;
    }

    private static WeatherForecasts.WeatherForecast DeleteWeatherForecast(Guid id)
    {
        var recordToDelete = WeatherForecastsStore.Store.FirstOrDefault(x => x.Id == id);

        WeatherForecastsStore.Store.Remove(recordToDelete);

        return recordToDelete;
    }
}
