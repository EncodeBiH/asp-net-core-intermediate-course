using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManager.Services;

public class AccessTokenService : IAccessTokenService
{
  private readonly IConfiguration _configuration;

  public AccessTokenService(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public string GetAccessToken()
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
      issuer: _configuration.GetValue<string>("JWT:Issuer"),
      claims: new List<Claim>()
      {
        new(JwtRegisteredClaimNames.Sub, "Emir Veledar"),
        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("D")),
        new("Demo", "demo"),
        new Claim(ClaimTypes.Role, "Admin")
      },
    expires: DateTime.UtcNow.AddMinutes(1),
      notBefore: DateTime.UtcNow,
      signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:SecurityKey"))),
        SecurityAlgorithms.HmacSha256Signature)
    );

    return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
  }
}
