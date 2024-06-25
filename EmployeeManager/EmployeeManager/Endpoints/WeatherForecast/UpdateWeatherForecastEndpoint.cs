using EmployeeManager.Filters;
using EmployeeManager.WeatherForecasts;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class UpdateWeatherForecastEndpoint
{
    public static IEndpointRouteBuilder MapUpdateWeatherForecastEndpoint(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPut("/weatherforecast/{id}", UpdateWeatherForecast)
            .WithRequestValidation<UpdateWeatherForecastRequest>()
			.WithTags("Weather Forecast")
            .WithOpenApi();

        return builder;
    }

    private static WeatherForecasts.WeatherForecast UpdateWeatherForecast(Guid id, UpdateWeatherForecastRequest request)
    {
        var forecast = WeatherForecastsStore.Store.FirstOrDefault(x => x.Id == id);

        forecast.Summary = request.Summary;
        forecast.TemperatureC = request.TemperatureC;

        return forecast;
    }
}

public class UpdateWeatherForecastRequest
{
    public int TemperatureC { get; set; }

	public string Summary { get; set; }
}
