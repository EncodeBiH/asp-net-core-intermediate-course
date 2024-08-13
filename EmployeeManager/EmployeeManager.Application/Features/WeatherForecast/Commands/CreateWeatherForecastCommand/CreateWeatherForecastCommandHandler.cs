namespace EmployeeManager.Application.Features.WeatherForecast.Commands.CreateWeatherForecastCommand;

public class CreateWeatherForecastCommandHandler : ICommandHandler<CreateWeatherForecastCommand, CreateWeatherForecastCommandResult>
{
	private readonly IApplicationDbContext _applicationDbContext;

	public CreateWeatherForecastCommandHandler
	(
		IApplicationDbContext applicationDbContext
	)
	{
		ArgumentNullException.ThrowIfNull(applicationDbContext);

		_applicationDbContext = applicationDbContext;
	}

	public async Task<CreateWeatherForecastCommandResult> Handle(CreateWeatherForecastCommand command, CancellationToken cancellationToken = default)
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