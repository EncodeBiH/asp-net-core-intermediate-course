using EmployeeManager.Application.Common;
using EmployeeManager.Database;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Application.Features.WeatherForecast.Queries.GetWeatherForecastsQuery;
public class GetWeatherForecastsQueryHandler : IQueryHandler<GetWeatherForecastsQuery, GetWeatherForecastsQueryResult>
{
	private readonly ApplicationDbContext _applicationDbContext;

	public GetWeatherForecastsQueryHandler
	(
		ApplicationDbContext applicationDbContext
	)
	{
		ArgumentNullException.ThrowIfNull(applicationDbContext);

		_applicationDbContext = applicationDbContext;
	}

	public async Task<GetWeatherForecastsQueryResult> HandleAsync(GetWeatherForecastsQuery request, CancellationToken cancellationToken = default)
	{
		var query = _applicationDbContext
			.WeatherForecasts
			.AsQueryable();

		query = ApplyFiltering(query, request);

		query = ApplySorting(query, request.SortBy, request.SortOrder);

		var result = await query
			.Select(x => new GetWeatherForecastsQueryResultWeatherForecast
			{
				Id = x.Id,
				Summary = x.Summary,
				TemperatureC = x.TemperatureC
			})
			.ToPagedListAsync(request.PageSize, request.PageNumber);

		return new GetWeatherForecastsQueryResult
		{
			WeatherForecasts = result
		};
	}

	private static IQueryable<Domain.Entities.WeatherForecast.WeatherForecast> ApplyFiltering(
		IQueryable<Domain.Entities.WeatherForecast.WeatherForecast> query,
		GetWeatherForecastsQuery request)
	{
		if (!string.IsNullOrWhiteSpace(request.SearchTerm))
		{
			query = query.Where(x => EF.Functions.Like(x.Summary, $"%{request.SearchTerm}%"));
		}

		return query;
	}

	private static IQueryable<Domain.Entities.WeatherForecast.WeatherForecast> ApplySorting(
		IQueryable<Domain.Entities.WeatherForecast.WeatherForecast> query,
		string sortBy,
		string sortOrder)
	{
		return sortBy switch
		{
			"date" => query.OrderByAscDesc(x => x.Date, sortOrder),
			"id" => query.OrderByAscDesc(x => x.Id, sortOrder),
			_ => query
		};
	}
}
