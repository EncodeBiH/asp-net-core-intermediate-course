using EmployeeManager.Application;
using EmployeeManager.Application.Features.WeatherForecast.Queries.GetWeatherForecastByIdQuery;

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
		IQueryHandler<GetWeatherForecastByIdQuery, GetWeatherForecastByIdQueryResult> queryHandler,
		CancellationToken cancellationToken)
	{
		var forecast = await queryHandler.HandleAsync(new GetWeatherForecastByIdQuery()
		{
			Id = id
		}, cancellationToken);

		return forecast;
	}
}