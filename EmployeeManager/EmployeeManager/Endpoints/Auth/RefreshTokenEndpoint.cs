using EmployeeManager.Services;
using EmployeeManager.WeatherForecasts;

namespace EmployeeManager.Endpoints.Auth;

public static class RefreshTokenEndpoint
{
  public static IEndpointRouteBuilder MapRefreshTokenEndpoint(this IEndpointRouteBuilder builder)
  {
    builder
      .MapPost("/api/refresh-token", RefreshToken);

    return builder;
  }

  private static IResult RefreshToken(RefreshTokenRequest request, IAccessTokenService accessTokenService)
  {
    var refreshTokenDb = TokenStore.Store.FirstOrDefault(x => x == request.RefreshToken);

    if (refreshTokenDb == null)
    {
      TypedResults.BadRequest("Unknown refresh token");
    }

    TokenStore.Store.Remove(refreshTokenDb);

    var newRefreshToken = Guid.NewGuid().ToString("D");
    TokenStore.Store.Add(newRefreshToken);

    var newAccessToken = accessTokenService.GetAccessToken();


    return TypedResults.Ok(new RefreshTokenResult
    {
      AccessToken = newAccessToken,
      RefreshToken = newRefreshToken
    });
  }
}

public class RefreshTokenRequest
{
  public string AccessToken { get; set; }

  public string RefreshToken { get; set; }
}

public class RefreshTokenResult
{
  public string AccessToken { get; set; }
  public string RefreshToken { get; set; }
}