using FluentValidation;

namespace EmployeeManager.Filters;

public class ValidationFilter<TRequest>(IValidator<TRequest> validator) : IEndpointFilter
{
	public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
	{
		if (validator is null)
		{
			throw new ArgumentNullException(nameof(validator));
		}

		var request = context
			.Arguments
			.OfType<TRequest>()
			.First();

		var validationResult = await validator.ValidateAsync(request);

		if (!validationResult.IsValid)
		{
			return TypedResults.ValidationProblem(validationResult.ToDictionary(), "Validation error occurs", "",
				"Request is not valid");
		}

		var endpointResult = await next(context);

		return endpointResult;
	}
}
