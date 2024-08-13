using MediatR;

namespace EmployeeManager.Application.PipelineBehaviours;
public  class TransactionBehaviour<TCommand, TResponse> : IPipelineBehavior<TCommand, TResponse>
{
	private readonly IApplicationDbContext _applicationDbContext;

	public TransactionBehaviour
	(
		IApplicationDbContext applicationDbContext
	)
	{
		ArgumentNullException.ThrowIfNull(applicationDbContext);

		_applicationDbContext = applicationDbContext;
	}

	public async Task<TResponse> Handle(TCommand request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		if (request is not (ICommand<TResponse> or ICommand))
		{
			return await next();
		}

		var transaction = await _applicationDbContext.Database.BeginTransactionAsync(cancellationToken);

		try
		{
			var response = await next();

			await transaction.CommitAsync(cancellationToken);

			return response;
		}
		catch(Exception ex)
		{
			await transaction.RollbackAsync(cancellationToken);

			throw;
		}
	}
}
