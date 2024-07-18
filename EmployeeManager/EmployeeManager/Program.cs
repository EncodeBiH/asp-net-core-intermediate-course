using System.Text;
using EmployeeManager.Database;
using EmployeeManager.Endpoints.Auth;
using EmployeeManager.Endpoints.WeatherForecast;
using EmployeeManager.Queries.GetWeatherForecastQuery;
using EmployeeManager.Services;
using EmployeeManager.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
  .AddDbContext<ApplicationDbContext>(options =>
  {
    options
      .UseSqlServer(builder.Configuration.GetConnectionString("Default"))
      .EnableSensitiveDataLogging();
  });

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
  .AddScoped<IGetWeatherForecastQuery, GetWeatherForecastQuery>();

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