using MediatR;

namespace EmployeeManager.Application;

public interface IQueryHandler<TQuery, TReponse> : IRequestHandler<TQuery, TReponse> where TQuery : IQuery<TReponse>
{
}