using EmployeeManager.Filters;
using EmployeeManager.WeatherForecasts;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class CreateWeatherForecastEndpoint
{
    public static IEndpointRouteBuilder MapCreateWeatherForecastEndpoint(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPost("/api/weatherforecast", CreateWeatherForecast)
            .WithRequestValidation<CreateWeatherForecastRequest>();

        return builder;
    }

    private static CreateWeatherForecastResponse CreateWeatherForecast(CreateWeatherForecastRequest request)
    {
        var forecast = new WeatherForecasts.WeatherForecast(request.Date, request.TemperatureC!.Value, request.Summary);

        WeatherForecastsStore.Store.Add(forecast);

        return new CreateWeatherForecastResponse(forecast.Id);
    }
}


public class CreateWeatherForecastRequest
{
	public DateOnly Date { get; set; }

	public int? TemperatureC { get; set; }

	public string Summary { get; set; }
}

public class CreateWeatherForecastResponse(Guid id)
{
	public Guid Id { get; set; } = id;
}