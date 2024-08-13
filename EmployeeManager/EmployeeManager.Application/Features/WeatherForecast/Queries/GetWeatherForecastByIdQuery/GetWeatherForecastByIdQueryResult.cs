namespace EmployeeManager.Application.Features.WeatherForecast.Queries.GetWeatherForecastByIdQuery;

public class GetWeatherForecastByIdQueryResult
{
	public Guid Id { get; set; }

	public int TemperatureC { get; set; }

	public string Summary { get; set; }
}
