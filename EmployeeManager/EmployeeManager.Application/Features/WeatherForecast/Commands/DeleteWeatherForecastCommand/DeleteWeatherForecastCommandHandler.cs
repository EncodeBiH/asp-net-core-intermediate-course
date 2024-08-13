using EmployeeManager.Database;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Application.Features.WeatherForecast.Commands.DeleteWeatherForecastCommand;

public class DeleteWeatherForecastCommandHandler : ICommandHandler<DeleteWeatherForecastCommand>
{
	private readonly ApplicationDbContext _applicationDbContext;

	public DeleteWeatherForecastCommandHandler
	(
		ApplicationDbContext applicationDbContext
	)
	{
		ArgumentNullException.ThrowIfNull(applicationDbContext);

		_applicationDbContext = applicationDbContext;
	}
	public async Task HandleAsync(DeleteWeatherForecastCommand command, CancellationToken cancellationToken = default)
	{
		var entity = await _applicationDbContext
			.WeatherForecasts
			.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

		if (entity is null)
		{
			throw new Exception("Weather forecast not found.");
		}

		_applicationDbContext.WeatherForecasts.Remove(entity);

		await _applicationDbContext.SaveChangesAsync(cancellationToken);
	}
}
