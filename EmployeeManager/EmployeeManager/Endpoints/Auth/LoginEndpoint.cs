using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeManager.Services;
using EmployeeManager.WeatherForecasts;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace EmployeeManager.Endpoints.Auth;

public static class LoginEndpoint
{
	public static IEndpointRouteBuilder MapLoginEndpoint(this IEndpointRouteBuilder builder)
	{
		builder
			.MapPost("/api/login", Login);

		return builder;
	}

	private static IResult Login(LoginEndpointRequest request, IAccessTokenService accessTokenService)
  {
    var jwtToken = accessTokenService.GetAccessToken();

		var refreshToken = Guid.NewGuid().ToString("D");
		TokenStore.Store.Add(refreshToken);

		return TypedResults.Ok(new LoginEndpointResult
    {
			RefreshToken = refreshToken,
			AccessToken = jwtToken
    });
	}
}

public class LoginEndpointRequest
{
	public string Username { get; set; }

	public string Password { get; set; }
}

public class LoginEndpointResult
{
  public string AccessToken { get; set; }

  public string RefreshToken { get; set; }
}
