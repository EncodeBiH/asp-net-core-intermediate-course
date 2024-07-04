using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

	private static IResult Login(LoginRequest request, IConfiguration configuration)
	{
		var claims = new Dictionary<string, object>()
		{
			{JwtRegisteredClaimNames.Sub, "Emir Veledar"},
			{JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("D")}
		};

		//var securityToken = new SecurityTokenDescriptor()
		//{
		//	Issuer = configuration.GetValue<string>("JWT:Issuer"),
		//	Expires = DateTime.UtcNow.AddMinutes(10),
		//	IssuedAt = DateTime.UtcNow,
		//	Claims = claims,
		//	SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(
		//		Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWT:SecurityKey"))), SecurityAlgorithms.HmacSha256Signature)
		//};
		//var tokenHandler = new JwtSecurityTokenHandler();
		//var jwtsecurityToken = tokenHandler.CreateJwtSecurityToken(securityToken);

		var jwtSecurityToken = new JwtSecurityToken
		(
			issuer: configuration.GetValue<string>("JWT:Issuer"),
			claims: new List<Claim>()
			{
				new(JwtRegisteredClaimNames.Sub, "Emir Veledar"),
				new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("D")),
				new("Demo", "demo"),
				new Claim(ClaimTypes.Role, "Admin")
			},
			expires: DateTime.UtcNow.AddMinutes(10),
			notBefore: DateTime.UtcNow,
			signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
					Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWT:SecurityKey"))),
				SecurityAlgorithms.HmacSha256Signature)
		);

		var jwtToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

		return TypedResults.Ok(jwtToken);
	}
}

public class LoginRequest
{
	public string Username { get; set; }

	public string Password { get; set; }
}
