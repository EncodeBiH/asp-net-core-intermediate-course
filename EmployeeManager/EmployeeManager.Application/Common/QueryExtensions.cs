using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Application.Common;

public static class QueryExtensions
{
  public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, int pageSize, int pageNumber)
  {
    var lastPage = (pageNumber <= 0 ? 1 : pageNumber) - 1;
    var skip = lastPage * pageSize;

    var totalRecords = await query.CountAsync();

    var items = await query
	    .Skip(skip)
	    .Take(pageSize)
	    .ToListAsync();

    decimal totalPages = (decimal)totalRecords / pageSize;

    return new PagedList<T>()
    {
      PageSize = pageSize,
      TotalRecords = totalRecords,
      Items = items,
      PageNumber = pageNumber,
      TotalPages = (int)Math.Ceiling(totalPages)
    };
  }

  public static IQueryable<T> OrderByAscDesc<T, TKey>(this IQueryable<T> query, Expression<Func<T,TKey>> orderColumn, string order)
  {
    return order switch
    {
      "asc" => query.OrderBy(orderColumn),
      "desc" => query.OrderByDescending(orderColumn),
      _ => query
    };
  }
}

public class PagedList<T>
{
  public int PageSize { get; set; }
  public int PageNumber { get; set; }
  public List<T> Items { get; set; }
  public int TotalRecords { get; set; }
  public int TotalPages { get; set; }
}
