using EmployeeManager.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManager.Persistence;

public static class DependencyInjection
{
	public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
	{
		services.AddDatabase(configuration, connectionStringName);

		return services;
	}

	private static void AddDatabase(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
		{
			options
				.UseSqlServer(configuration.GetConnectionString(connectionStringName))
				.EnableSensitiveDataLogging();
		});

		services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
	}
}
