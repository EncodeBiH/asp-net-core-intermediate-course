namespace EmployeeManager.Application.Features.WeatherForecast.Queries.GetWeatherForecastByIdQuery;

public class GetWeatherForecastByIdQuery : IQuery<GetWeatherForecastByIdQueryResult>
{
	public Guid Id { get; set; }
}
