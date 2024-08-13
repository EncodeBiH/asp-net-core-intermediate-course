using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Application.Features.WeatherForecast.Queries.GetWeatherForecastByIdQuery;

internal class GetWeatherForecastByIdQueryHandler : IQueryHandler<GetWeatherForecastByIdQuery, GetWeatherForecastByIdQueryResult>
{
	private readonly IApplicationDbContext _applicationDbContext;

	public GetWeatherForecastByIdQueryHandler
	(
		IApplicationDbContext applicationDbContext
	)
	{
		ArgumentNullException.ThrowIfNull(applicationDbContext);

		_applicationDbContext = applicationDbContext;
	}

	public async Task<GetWeatherForecastByIdQueryResult> Handle(GetWeatherForecastByIdQuery query, CancellationToken cancellationToken = default)
	{
		var result = await _applicationDbContext
			.WeatherForecasts
			.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken: cancellationToken);

		if (result is null)
		{
			throw new Exception("Weather forecast not found.");
		}

		return new GetWeatherForecastByIdQueryResult()
		{
			Id = result.Id,
			Summary = result.Summary,
			TemperatureC = result.TemperatureC
		};
	}
}
