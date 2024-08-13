namespace EmployeeManager.Application.Features.WeatherForecast.Queries.GetWeatherForecastsQuery;

public class GetWeatherForecastsQuery : IQuery<GetWeatherForecastsQueryResult>
{
	public int PageSize { get; set; }

	public int PageNumber { get; set; }

	public string SearchTerm { get; set; }

	public string SortBy { get; set; }

	public string SortOrder { get; set; }
}
