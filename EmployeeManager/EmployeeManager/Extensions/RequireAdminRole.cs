namespace EmployeeManager.Extensions;

public static class RequireAdminRoleExtension
{
  public static RouteHandlerBuilder RequireAdminRole(this RouteHandlerBuilder builder)
  {
    builder
      .RequireAuthorization(x => x.RequireRole("Admin"));

    return builder;
  }

  public static RouteHandlerBuilder RequireAgeClaim(this RouteHandlerBuilder builder)
  {
    builder
      .RequireAuthorization(x => x.RequireClaim("Admin"));

    return builder;
  }

  public static RouteHandlerBuilder RequireAuthenticatedUser(this RouteHandlerBuilder builder)
  {
    builder
      .RequireAuthorization(x => x.RequireAuthenticatedUser());

    return builder;
  }
}
