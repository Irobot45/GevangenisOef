using MediatR;

namespace Gevangenis.Contracts.Queries;

public class QueryBase<T> : IRequest<T> where T : class
{
}
