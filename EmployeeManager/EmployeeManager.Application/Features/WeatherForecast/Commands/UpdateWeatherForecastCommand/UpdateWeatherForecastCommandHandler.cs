using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Application.Features.WeatherForecast.Commands.UpdateWeatherForecastCommand;

public class UpdateWeatherForecastCommandHandler : ICommandHandler<UpdateWeatherForecastCommand, UpdateWeatherForecastCommandResult>
{
	private readonly IApplicationDbContext _applicationDbContext;

	public UpdateWeatherForecastCommandHandler
	(
		IApplicationDbContext applicationDbContext
	)
	{
		ArgumentNullException.ThrowIfNull(applicationDbContext);

		_applicationDbContext = applicationDbContext;
	}

	public async Task<UpdateWeatherForecastCommandResult> Handle(UpdateWeatherForecastCommand command, CancellationToken cancellationToken = default)
	{
		var entity = await _applicationDbContext
			.WeatherForecasts
			.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

		if (entity is null)
		{
			throw new Exception("Weather forecast not found.");
		}

		entity.Summary = command.Summary;
		entity.TemperatureC = command.TemperatureC;

		await _applicationDbContext.SaveChangesAsync(cancellationToken);

		return new UpdateWeatherForecastCommandResult
		{
			Id = entity.Id
		};
	}
}
