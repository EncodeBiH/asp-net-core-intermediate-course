using System.Text;
using EmployeeManager.Endpoints.Auth;
using EmployeeManager.Endpoints.WeatherForecast;
using EmployeeManager.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder
	.Services
	.AddValidatorsFromAssembly(typeof(CreateWeatherForecastEndpointValidator).Assembly);

builder
	.Services
	.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters()
		{
			ValidateIssuer = true,
			ValidIssuer = builder.Configuration.GetValue<string>("JWT:Issuer"),
			ValidateAudience = false,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey =
				new SymmetricSecurityKey(
					Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JWT:SecurityKey")))
		};
	});

builder
	.Services
	.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app
	.UseAuthentication()
	.UseAuthorization();


// Auth Endpoints
app
	.MapLoginEndpoint();

// Weather forecast endpoints
app
	.MapGetWeatherForecastEndpoint()
	.MapCreateWeatherForecastEndpoint()
	.MapUpdateWeatherForecastEndpoint()
	.MapDeleteWeatherForecastEndpoint()
	.MapGetWeatherForecastByIdEndpoint();

app.Run();