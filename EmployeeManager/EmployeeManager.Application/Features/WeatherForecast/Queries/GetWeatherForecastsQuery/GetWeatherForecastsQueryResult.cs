using EmployeeManager.Application.Common;

namespace EmployeeManager.Application.Features.WeatherForecast.Queries.GetWeatherForecastsQuery;

public class GetWeatherForecastsQueryResult
{
	public PagedList<GetWeatherForecastsQueryResultWeatherForecast> WeatherForecasts { get; set; }
}

public class GetWeatherForecastsQueryResultWeatherForecast
{
	public Guid Id { get; set; }

	public int TemperatureC { get; set; }

	public string Summary { get; set; }

	public DateOnly Date { get; set; }
}
