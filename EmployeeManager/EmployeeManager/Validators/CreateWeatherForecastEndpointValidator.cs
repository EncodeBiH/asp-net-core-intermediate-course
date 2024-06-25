using EmployeeManager.Endpoints.WeatherForecast;
using FluentValidation;

namespace EmployeeManager.Validators;

public class CreateWeatherForecastEndpointValidator : AbstractValidator<CreateWeatherForecastRequest>
{
    public CreateWeatherForecastEndpointValidator()
    {
	    RuleFor(x => x.Summary)
		    .Cascade(CascadeMode.Stop)
		    .NotNull()
		    .NotEmpty();

	    RuleFor(x => x.TemperatureC)
		    .NotNull();
    }
}
