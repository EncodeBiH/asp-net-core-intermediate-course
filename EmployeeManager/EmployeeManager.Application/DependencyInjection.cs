using EmployeeManager.Application.PipelineBehaviours;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManager.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(configuration =>
		{
			configuration.RegisterServicesFromAssembly(AssemblyReference.Assembly);

			configuration.AddOpenBehavior(typeof(TransactionBehaviour<,>));
		});

		return services;
	}
}
