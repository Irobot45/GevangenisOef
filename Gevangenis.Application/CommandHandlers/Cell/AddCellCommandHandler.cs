using FluentValidation;
using FluentValidation.Results;
using Gevangenis.Contracts.Commands;
using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;

namespace Gevangenis.Application.CommandHandlers
{
    public class AddCellCommandHandler : IRequestHandler<AddCellCommand, Cell>
    {
        private readonly IRepository<Cell> _repository;

        public AddCellCommandHandler(IRepository<Cell> repository)
        {
            this._repository = repository;
        }
        public async Task<Cell> Handle(AddCellCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await new AddCellCommandValidator().ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            Cell c = new Cell(request.Prison);
            if(request.Prisoners != null)
            {
                c.TryAddPrisoners(request.Prisoners);
            }
            c.Capacity = request.Capacity;
            c.IsIsolationCell = request.IsIsolationCell;
            _repository.Add(c);
            await _repository.SaveChangesAsync();

            return c;
        }
    }
}
