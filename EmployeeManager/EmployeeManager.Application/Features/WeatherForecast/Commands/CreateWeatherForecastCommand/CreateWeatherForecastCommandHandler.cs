using EmployeeManager.Database;

namespace EmployeeManager.Application.Features.WeatherForecast.Commands.CreateWeatherForecastCommand;

public class CreateWeatherForecastCommandHandler : ICommandHandler<CreateWeatherForecastCommand, CreateWeatherForecastCommandResult>
{
	private readonly ApplicationDbContext _applicationDbContext;

	public CreateWeatherForecastCommandHandler
	(
		ApplicationDbContext applicationDbContext
	)
	{
		ArgumentNullException.ThrowIfNull(applicationDbContext);

		_applicationDbContext = applicationDbContext;
	}

	public async Task<CreateWeatherForecastCommandResult> HandleAsync(CreateWeatherForecastCommand command, CancellationToken cancellationToken = default)
	{
		var entity = new Domain.Entities.WeatherForecast.WeatherForecast(command.Date, command.TemperatureC!.Value, command.Summary);

		_applicationDbContext.WeatherForecasts.Add(entity);

		await _applicationDbContext.SaveChangesAsync(cancellationToken);

		return new CreateWeatherForecastCommandResult
		{
			Id = entity.Id
		};
	}
}