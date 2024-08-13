namespace EmployeeManager.Application.Features.WeatherForecast.Commands.CreateWeatherForecastCommand;

public class CreateWeatherForecastCommand : ICommand<CreateWeatherForecastCommandResult>
{
	public DateOnly Date { get; set; }

	public int? TemperatureC { get; set; }

	public string Summary { get; set; }
}
