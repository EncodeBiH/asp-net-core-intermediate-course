using EmployeeManager.Extensions;

namespace EmployeeManager.Queries.GetWeatherForecastQuery;

public interface IGetWeatherForecastQuery
{
  GetWeatherForecastQueryResult ExecuteQuery(GetWeatherForecastQueryRequest query);
}

public class GetWeatherForecastQueryResult
{
  public PagedList<WeatherForecasts.WeatherForecast> WeatherForecasts { get; set; }
}

public class GetWeatherForecastQueryRequest
{
  public int PageSize { get; set; }

  public int PageNumber { get; set; }

  public string SearchTerm { get; set; }

  public string SortBy { get; set; }

  public string SortOrder { get; set; }
}