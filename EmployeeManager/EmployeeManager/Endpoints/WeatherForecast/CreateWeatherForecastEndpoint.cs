using EmployeeManager.Application;
using EmployeeManager.Application.Features.WeatherForecast.Commands.CreateWeatherForecastCommand;
using EmployeeManager.Extensions;
using EmployeeManager.Filters;

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
		ICommandHandler<CreateWeatherForecastCommand, CreateWeatherForecastCommandResult> commandHandler,
		CancellationToken cancellationToken
	)
	{
		var result = await commandHandler.HandleAsync(request, cancellationToken);

		return result;
	}
}