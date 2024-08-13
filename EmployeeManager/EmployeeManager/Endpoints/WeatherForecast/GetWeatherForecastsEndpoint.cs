using EmployeeManager.Application.Common;
using EmployeeManager.Application.Features.WeatherForecast.Queries.GetWeatherForecastsQuery;
using MediatR;

namespace EmployeeManager.Endpoints.WeatherForecast;

public static class GetWeatherForecastsEndpoint
{
  public static IEndpointRouteBuilder MapGetWeatherForecastEndpoint(this IEndpointRouteBuilder builder)
  {
    builder
        .MapGet("/api/weatherforecasts", GetWeatherForecast)
        .RequireAuthorization(x => x.RequireAuthenticatedUser());

    return builder;
  }

  private static async Task<GetWeatherForecastsQueryResult> GetWeatherForecast
	  (
		  GetWeatherForecastEndpointRequest request, 
		  ISender sender, 
		  CancellationToken cancellationToken
		  )
  {
	  var result = await sender.Send(new GetWeatherForecastsQuery()
	  {
		  PageNumber = request.PageNumber,
		  PageSize = request.PageSize,
		  SearchTerm = request.SearchTerm,
		  SortBy = request.SortBy,
		  SortOrder = request.SortOrder
	  }, cancellationToken);

	  return result;
  }
}

public class GetWeatherForecastEndpointRequest
{
  public int PageSize { get; set; }

  public int PageNumber { get; set; }

  public string SearchTerm { get; set; }

  public string SortBy { get; set; }

  public string SortOrder { get; set; }

  public static async ValueTask<GetWeatherForecastEndpointRequest> BindAsync(HttpContext context)
  {
    var pageSize = int.Parse(context.Request.Query["pageSize"]);
    var pageNumber = int.Parse(context.Request.Query["pageNumber"]);
    var searchTerm = context.Request.Query["searchTerm"];
    var sortBy = context.Request.Query["sortBy"];
    var sortOrder = context.Request.Query["sortOrder"];

    return new GetWeatherForecastEndpointRequest
    {
      PageNumber = pageNumber,
      PageSize = pageSize,
      SearchTerm = searchTerm,
      SortBy = sortBy,
      SortOrder = sortOrder
    };
  }

  //public static bool TryParse(string value, out GetWeatherForecastEndpointRequest request)
  //{
  //  request = new GetWeatherForecastEndpointRequest();
  //  return true;
  //}
}

public class GetWeatherForecastEndpointResponse
{
  public PagedList<Domain.Entities.WeatherForecast.WeatherForecast> WeatherForecasts { get; set; }
}