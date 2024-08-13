using EmployeeManager.Application;
using EmployeeManager.Application.Features.WeatherForecast.Commands.UpdateWeatherForecastCommand;
using EmployeeManager.Filters;
using MediatR;

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
		ISender sender,
		CancellationToken cancellationToken
	)
	{
		var result = await sender.Send(new UpdateWeatherForecastCommand
		{
			Id = id,
			Summary = request.Summary,
			TemperatureC = request.TemperatureC
		}, cancellationToken);

		return result;
	}
}

public class UpdateWeatherForecastRequest
{
	public int TemperatureC { get; set; }

	public string Summary { get; set; }
}