namespace EmployeeManager.Application.Features.WeatherForecast.Commands.UpdateWeatherForecastCommand;

public class UpdateWeatherForecastCommand : ICommand<UpdateWeatherForecastCommandResult>
{
	public Guid Id { get; set; }

	public int TemperatureC { get; set; }

	public string Summary { get; set; }
}
