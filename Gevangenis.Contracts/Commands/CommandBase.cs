using MediatR;

namespace Gevangenis.Contracts.Commands;

public class CommandBase<T> : IRequest<T> where T : class
{

}
