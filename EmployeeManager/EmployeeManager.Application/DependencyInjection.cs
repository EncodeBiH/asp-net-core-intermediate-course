using EmployeeManager.Application.Features.WeatherForecast.Commands.CreateWeatherForecastCommand;
using EmployeeManager.Application.Features.WeatherForecast.Commands.DeleteWeatherForecastCommand;
using EmployeeManager.Application.Features.WeatherForecast.Commands.UpdateWeatherForecastCommand;
using EmployeeManager.Application.Features.WeatherForecast.Queries.GetWeatherForecastByIdQuery;
using EmployeeManager.Application.Features.WeatherForecast.Queries.GetWeatherForecastsQuery;
using EmployeeManager.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManager.Application;

public static class DependencyInjection
{
	public static void AddApplication(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
	{
		services.AddDatabase(configuration, connectionStringName);

		services
			.AddScoped<ICommandHandler<CreateWeatherForecastCommand, CreateWeatherForecastCommandResult>, CreateWeatherForecastCommandHandler>()
			.AddScoped<ICommandHandler<UpdateWeatherForecastCommand, UpdateWeatherForecastCommandResult>, UpdateWeatherForecastCommandHandler>()
			.AddScoped<ICommandHandler<DeleteWeatherForecastCommand>, DeleteWeatherForecastCommandHandler>()
			.AddScoped<IQueryHandler<GetWeatherForecastsQuery, GetWeatherForecastsQueryResult>, GetWeatherForecastsQueryHandler>()
			.AddScoped<IQueryHandler<GetWeatherForecastByIdQuery, GetWeatherForecastByIdQueryResult>, GetWeatherForecastByIdQueryHandler>();
	}


	private static void AddDatabase(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
		{
			options
				.UseSqlServer(configuration.GetConnectionString(connectionStringName))
				.EnableSensitiveDataLogging();
		});
	}
}
