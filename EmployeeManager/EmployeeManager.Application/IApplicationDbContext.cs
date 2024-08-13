using EmployeeManager.Domain.Entities.WeatherForecast;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EmployeeManager.Application;

public interface IApplicationDbContext
{
	DbSet<WeatherForecast> WeatherForecasts { get; set; }

	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

	DatabaseFacade Database { get; }
}
