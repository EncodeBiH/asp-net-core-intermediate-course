using EmployeeManager.Domain.Entities.WeatherForecast;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManager.Persistence.Configuration;

public class WeatherForecastEntityTypeConfiguration : IEntityTypeConfiguration<WeatherForecast>
{
	public void Configure(EntityTypeBuilder<WeatherForecast> builder)
	{
		builder
			.HasKey(x => x.Id);

		builder
			.Property(x => x.Summary)
			.HasMaxLength(2048);
	}
}
