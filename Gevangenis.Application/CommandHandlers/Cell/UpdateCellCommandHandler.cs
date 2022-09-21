using FluentValidation;
using FluentValidation.Results;
using Gevangenis.Contracts.Commands;
using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;

namespace Gevangenis.Application.CommandHandlers
{
    public class UpdateCellCommandHandler : IRequestHandler<UpdateCellCommand, Cell>
    {
        private readonly IRepository<Cell> _repository;

        public UpdateCellCommandHandler(IRepository<Cell> repository)
        {
            this._repository = repository;
        }
        public async Task<Cell> Handle(UpdateCellCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await new UpdateCellCommandValidator().ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            Cell c = await _repository.GetAsync(c => c.Id == request.Id && c.IsDeleted == false);

            if (request.Capacity != null) c.Capacity = request.Capacity.Value;
            if (request.Prisoners != null) c.UpdatePrisoners((List<Prisoner>)request.Prisoners);
            if (request.Prison != null) c.Prison = request.Prison;
            if (request.IsIsolationCell != null) c.IsIsolationCell = request.IsIsolationCell.Value;
            _repository.Update(c);
            await _repository.SaveChangesAsync();

            return c;
        }
    }
}
