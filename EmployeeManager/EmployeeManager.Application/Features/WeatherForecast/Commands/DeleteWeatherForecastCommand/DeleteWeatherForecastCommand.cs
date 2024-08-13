namespace EmployeeManager.Application.Features.WeatherForecast.Commands.DeleteWeatherForecastCommand;

public class DeleteWeatherForecastCommand : ICommand
{
	public Guid Id { get; set; }
}
