using EmployeeManager.Application;
using EmployeeManager.Application.Features.WeatherForecast.Queries.GetWeatherForecastByIdQuery;
using MediatR;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class GetWeatherForecastByIdEndpoint
{
	public static IEndpointRouteBuilder MapGetWeatherForecastByIdEndpoint(this IEndpointRouteBuilder builder)
	{
		builder
			.MapGet("/api/weatherforecast/{id}", GetWeatherForecastById);

		return builder;
	}

	private static async Task<GetWeatherForecastByIdQueryResult> GetWeatherForecastById
	(
		Guid id,
		ISender sender,
		CancellationToken cancellationToken)
	{
		var forecast = await sender.Send(new GetWeatherForecastByIdQuery()
		{
			Id = id
		}, cancellationToken);

		return forecast;
	}
}