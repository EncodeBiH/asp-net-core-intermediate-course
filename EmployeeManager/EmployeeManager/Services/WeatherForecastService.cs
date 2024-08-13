using EmployeeManager.Domain.Entities.WeatherForecast;

namespace EmployeeManager.Services;

public interface IWeatherForecastService
{
	WeatherForecast GetWeatherForecastByParams(string searchTerm);

	WeatherForecast GetWeatherForecastForToday(string searchTearm);

	WeatherForecast GetWeatherForecastForYesterday(string searchTearm);

	void Update();

	void Insert();

	void InsertFromApi();
}
