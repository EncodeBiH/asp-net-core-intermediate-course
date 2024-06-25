namespace EmployeeManager.Filters;

public static class ValidationEndpointExtensions
{
	public static RouteHandlerBuilder WithRequestValidation<TRequest>(this RouteHandlerBuilder routeHandlerBuilder)
	{
		return routeHandlerBuilder
			.AddEndpointFilter<ValidationFilter<TRequest>>()
			.ProducesValidationProblem();
	}
}