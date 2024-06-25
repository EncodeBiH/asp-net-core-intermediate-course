using EmployeeManager.Endpoints.WeatherForecast;
using FluentValidation;

namespace EmployeeManager.Validators;

public class UpdateWeatherForecastEndpointValidator : AbstractValidator<UpdateWeatherForecastRequest>
{
	public UpdateWeatherForecastEndpointValidator()
	{
		RuleFor(x => x.Summary)
			.NotNull()
			.NotEmpty();
	}
}
