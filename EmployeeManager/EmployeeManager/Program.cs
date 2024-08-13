using EmployeeManager.Application;
using EmployeeManager.Endpoints.Auth;
using EmployeeManager.Endpoints.WeatherForecast;
using EmployeeManager.Persistence;
using EmployeeManager.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder
	.Services
	.AddValidatorsFromAssembly(typeof(UpdateWeatherForecastRequest).Assembly);

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
			ClockSkew = TimeSpan.Zero,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey =
				new SymmetricSecurityKey(
					Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JWT:SecurityKey")))
		};
	});

builder
	.Services
	.AddAuthorization();

builder
  .Services
  .AddIdentityApiEndpoints<IdentityUser>()
  .AddEntityFrameworkStores<ApplicationDbContext>();

builder
  .Services
  .AddScoped<IAccessTokenService, AccessTokenService>();

builder
	.Services
	.AddApplication()
	.AddPersistence(builder.Configuration, "Default");

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
	.MapLoginEndpoint()
  .MapRefreshTokenEndpoint();

// Weather forecast endpoints
app
	.MapGetWeatherForecastEndpoint()
	.MapCreateWeatherForecastEndpoint()
	.MapUpdateWeatherForecastEndpoint()
	.MapDeleteWeatherForecastEndpoint()
	.MapGetWeatherForecastByIdEndpoint();

app
  .MapIdentityApi<IdentityUser>();

app.Run();