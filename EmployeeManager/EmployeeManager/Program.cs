using EmployeeManager.Endpoints.WeatherForecast;
using EmployeeManager.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder
	.Services
	.AddValidatorsFromAssembly(typeof(CreateWeatherForecastEndpointValidator).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGetWeatherForecastEndpoint()
    .MapCreateWeatherForecastEndpoint()
    .MapUpdateWeatherForecastEndpoint()
    .MapDeleteWeatherForecastEndpoint()
    .MapGetWeatherForecastByIdEndpoint();

app.Run();
