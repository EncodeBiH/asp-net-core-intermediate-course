using EmployeeManager.Application.Features.WeatherForecast.Commands.CreateWeatherForecastCommand;
using EmployeeManager.Extensions;
using MediatR;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class CreateWeatherForecastEndpoint
{
	public static IEndpointRouteBuilder MapCreateWeatherForecastEndpoint(this IEndpointRouteBuilder builder)
	{
		builder
			.MapPost("/api/weatherforecasts", CreateWeatherForecast)
			.RequireAuthenticatedUser();

		return builder;
	}

	private static async Task<CreateWeatherForecastCommandResult> CreateWeatherForecast
	(
		CreateWeatherForecastCommand request,
		ISender mediator,
		CancellationToken cancellationToken
	)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result;
	}
}