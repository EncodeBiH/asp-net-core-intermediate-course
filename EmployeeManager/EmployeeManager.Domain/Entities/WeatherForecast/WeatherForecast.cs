﻿namespace EmployeeManager.Domain.Entities.WeatherForecast;

public class WeatherForecast
{
	public DateOnly Date { get; set; }
	public int TemperatureC { get; set; }
	public string? Summary { get; set; }

	public Guid Id { get; set; } = Guid.NewGuid();

	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

	public WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
	{
		this.Date = Date;
		this.TemperatureC = TemperatureC;
		this.Summary = Summary;
	}
}