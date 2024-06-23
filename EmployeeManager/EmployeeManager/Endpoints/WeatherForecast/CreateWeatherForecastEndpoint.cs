using EmployeeManager.WeatherForecasts;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class CreateWeatherForecastEndpoint
{
    public static IEndpointRouteBuilder MapCreateWeatherForecastEndpoint(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPost("/weatherforecast", CreateWeatherForecast)
            .WithTags("Weather Forecast")
            .WithOpenApi();

        return builder;
    }

    private static WeatherForecasts.WeatherForecast CreateWeatherForecast(CreateWeatherForecastRequest request)
    {
        var forecast = new WeatherForecasts.WeatherForecast(request.Date, request.TemperatureC, request.Summary);

        WeatherForecastsStore.Store.Add(forecast);

        return forecast;
    }
}


public class CreateWeatherForecastRequest
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string Summary { get; set; }
}