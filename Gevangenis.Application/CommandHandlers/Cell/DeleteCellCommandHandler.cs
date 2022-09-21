using FluentValidation;
using FluentValidation.Results;
using Gevangenis.Contracts.Commands;
using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;

namespace Gevangenis.Application.CommandHandlers
{
    public class DeleteCellCommandHandler : IRequestHandler<DeleteCellCommand, Cell>
    {
        private readonly IRepository<Cell> _repository;

        public DeleteCellCommandHandler(IRepository<Cell> repository)
        {
            this._repository = repository;
        }
        public async Task<Cell> Handle(DeleteCellCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await new DeleteCellCommandValidator().ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            Cell c = await _repository.GetAsync(p => p.Id == request.Id && p.IsDeleted == false);
            _repository.Delete(c);
            await _repository.SaveChangesAsync();

            return c;
        }
    }
}
