using EmployeeManager.Database;
using EmployeeManager.Filters;
using EmployeeManager.WeatherForecasts;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class UpdateWeatherForecastEndpoint
{
  public static IEndpointRouteBuilder MapUpdateWeatherForecastEndpoint(this IEndpointRouteBuilder builder)
  {
    builder
        .MapPut("/api/weatherforecast/{id}", UpdateWeatherForecast)
        .WithRequestValidation<UpdateWeatherForecastRequest>();

    return builder;
  }

  private static WeatherForecasts.WeatherForecast UpdateWeatherForecast(Guid id, UpdateWeatherForecastRequest request, ApplicationDbContext context)
  {
    var forecast = context.WeatherForecasts.FirstOrDefault(x => x.Id == id);

    forecast.Summary = request.Summary;
    forecast.TemperatureC = request.TemperatureC;

    context.SaveChanges();

    return forecast;
  }
}

public class UpdateWeatherForecastRequest
{
  public int TemperatureC { get; set; }

  public string Summary { get; set; }
}
