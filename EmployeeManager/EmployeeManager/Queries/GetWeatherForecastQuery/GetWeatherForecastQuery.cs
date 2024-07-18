using Azure.Core;
using EmployeeManager.Database;
using EmployeeManager.Endpoints.WeatherForecast;
using EmployeeManager.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Queries.GetWeatherForecastQuery;

public class GetWeatherForecastQuery : IGetWeatherForecastQuery
{
  private readonly ApplicationDbContext _context;

  public GetWeatherForecastQuery(ApplicationDbContext context)
  {
    _context = context;
  }

  public GetWeatherForecastQueryResult ExecuteQuery(GetWeatherForecastQueryRequest queryRequest)
  {
    var query = _context
    .WeatherForecasts
    .AsQueryable();

    query = ApplyFiltering(query, queryRequest);
    query = ApplySorting(query, queryRequest.SortBy, queryRequest.SortOrder);
    var result = query.ToPagedList(queryRequest.PageSize, queryRequest.PageNumber);

    return new GetWeatherForecastQueryResult
    {
      WeatherForecasts = result
    };
  }

  private static IQueryable<WeatherForecasts.WeatherForecast> ApplyFiltering(
    IQueryable<WeatherForecasts.WeatherForecast> query,
    GetWeatherForecastQueryRequest request)
  {
    if (!string.IsNullOrWhiteSpace(request.SearchTerm))
    {
      query = query.Where(x => EF.Functions.Like(x.Summary, $"%{request.SearchTerm}%"));
    }

    return query;
  }

  private static IQueryable<WeatherForecasts.WeatherForecast> ApplySorting(
    IQueryable<WeatherForecasts.WeatherForecast> query,
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