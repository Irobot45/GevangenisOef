using FluentValidation;
using FluentValidation.Results;
using Gevangenis.Contracts.Commands;
using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;

namespace Gevangenis.Application.CommandHandlers
{
    public class DeletePrisonerCommandHandler : IRequestHandler<DeletePrisonerCommand, Prisoner>
    {
        private readonly IRepository<Prisoner> _repository;

        public DeletePrisonerCommandHandler(IRepository<Prisoner> repository)
        {
            this._repository = repository;
        }
        public async Task<Prisoner> Handle(DeletePrisonerCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await new DeletePrisonerCommandValidator().ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            Prisoner p = await _repository.GetAsync(p => p.Id == request.Id && p.IsDeleted == false);
            _repository.Delete(p);
            await _repository.SaveChangesAsync();

            return p;
        }
    }
}
