using EmployeeManager.Application;
using EmployeeManager.Application.Features.WeatherForecast.Commands.DeleteWeatherForecastCommand;
using EmployeeManager.Extensions;

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

	private static async Task DeleteWeatherForecast(Guid id, ICommandHandler<DeleteWeatherForecastCommand> commandHandler)
	{
		await commandHandler.HandleAsync(new DeleteWeatherForecastCommand
		{
			Id = id
		});
	}
}