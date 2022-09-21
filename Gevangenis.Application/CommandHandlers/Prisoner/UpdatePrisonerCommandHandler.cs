using FluentValidation;
using FluentValidation.Results;
using Gevangenis.Contracts.Commands;
using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;

namespace Gevangenis.Application.CommandHandlers
{
    public class UpdatePrisonerCommandHandler : IRequestHandler<UpdatePrisonerCommand, Prisoner>
    {
        private readonly IRepository<Prisoner> _repository;

        public UpdatePrisonerCommandHandler(IRepository<Prisoner> repository)
        {
            this._repository = repository;
        }
        public async Task<Prisoner> Handle(UpdatePrisonerCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await new UpdatePrisonerCommandValidator().ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            Prisoner p = await _repository.GetAsync(c => c.Id == request.Id && c.IsDeleted == false);
            if (request.Name != null) { p.Name = request.Name; }
            if (request.EnterPrisonDateTime != null) p.EnterPrisonDateTime = request.EnterPrisonDateTime.Value;
            if (request.EndDateTimeSentence != null) p.EndDateTimeSentence = request.EndDateTimeSentence.Value;
            if (request.Cell != null) { p.Cell = request.Cell; }
            if (request.Prison != null) { p.Prison = request.Prison; }
            if (request.PrisonerType != null) { p.PrisonerType = request.PrisonerType.Value; }
            _repository.Update(p);
            await _repository.SaveChangesAsync();

            return p;
        }
    }
}
