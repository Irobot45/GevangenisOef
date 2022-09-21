using FluentValidation;
using FluentValidation.Results;
using Gevangenis.Contracts.Commands;
using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;

namespace Gevangenis.Application.CommandHandlers
{
    public class UpdatePrisonCommandHandler : IRequestHandler<UpdatePrisonCommand, Prison>
    {
        private readonly IRepository<Prison> _repository;

        public UpdatePrisonCommandHandler(IRepository<Prison> repository)
        {
            this._repository = repository;
        }
        public async Task<Prison> Handle(UpdatePrisonCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await new UpdatePrisonCommandValidator().ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            Prison p = await _repository.GetAsync(p => p.Id == request.Id && p.IsDeleted == false);

            if (!string.IsNullOrEmpty(request.Name)) p.Name = request.Name;
            if (request.Cells != null) p.UpdateCells((List<Cell>)request.Cells);
            _repository.Update(p);
            await _repository.SaveChangesAsync();

            return p;
        }
    }
}
