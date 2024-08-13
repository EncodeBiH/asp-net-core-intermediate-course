using EmployeeManager.Application;
using EmployeeManager.Application.Features.WeatherForecast.Commands.DeleteWeatherForecastCommand;
using EmployeeManager.Extensions;
using MediatR;

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

	private static async Task DeleteWeatherForecast(Guid id, ISender sender)
	{
		await sender.Send(new DeleteWeatherForecastCommand
		{
			Id = id
		});
	}
}