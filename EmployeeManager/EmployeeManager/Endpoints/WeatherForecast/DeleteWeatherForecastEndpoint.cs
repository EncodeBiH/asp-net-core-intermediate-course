using EmployeeManager.Database;
using EmployeeManager.Extensions;
using EmployeeManager.WeatherForecasts;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class DeleteWeatherForecastEndpoint
{
  public static IEndpointRouteBuilder MapDeleteWeatherForecastEndpoint(this IEndpointRouteBuilder builder)
  {
    builder
      .MapDelete("/api/weatherforecast/{id}", DeleteWeatherForecast)
      .RequireAuthenticatedUser();

    return builder;
  }

  private static WeatherForecasts.WeatherForecast DeleteWeatherForecast(Guid id, ApplicationDbContext context)
  {
    var recordToDelete = context.WeatherForecasts.FirstOrDefault(x => x.Id == id);

    context.WeatherForecasts.Remove(recordToDelete);

    context.SaveChanges();

    return recordToDelete;
  }
}