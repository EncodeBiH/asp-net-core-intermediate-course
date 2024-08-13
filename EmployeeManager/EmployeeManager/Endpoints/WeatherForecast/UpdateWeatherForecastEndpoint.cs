using EmployeeManager.Application;
using EmployeeManager.Application.Features.WeatherForecast.Commands.UpdateWeatherForecastCommand;
using EmployeeManager.Database;
using EmployeeManager.Filters;

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

	private static async Task<UpdateWeatherForecastCommandResult> UpdateWeatherForecast
	(
		Guid id,
		UpdateWeatherForecastRequest request,
		ICommandHandler<UpdateWeatherForecastCommand, UpdateWeatherForecastCommandResult> commandHandler
	)
	{
		var result = await commandHandler.HandleAsync(new UpdateWeatherForecastCommand
		{
			Id = id,
			Summary = request.Summary,
			TemperatureC = request.TemperatureC
		});

		return result;
	}
}

public class UpdateWeatherForecastRequest
{
	public int TemperatureC { get; set; }

	public string Summary { get; set; }
}