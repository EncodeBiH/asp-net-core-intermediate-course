namespace EmployeeManager.Application;

public interface IQueryHandler<TQuery, TReponse> where TQuery : IQuery<TReponse>
{
	Task<TReponse> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}