using FluentValidation;
using FluentValidation.Results;
using Gevangenis.Contracts.Commands;
using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;

namespace Gevangenis.Application.CommandHandlers
{
    public class AddPrisonerCommandHandler : IRequestHandler<AddPrisonerCommand, Prisoner>
    {
        private readonly IRepository<Prisoner> _repository;

        public AddPrisonerCommandHandler(IRepository<Prisoner> repository)
        {
            this._repository = repository;
        }
        public async Task<Prisoner> Handle(AddPrisonerCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await new AddPrisonerCommandValidator().ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            Prisoner p = new Prisoner();
            if(request.Name != null){p.Name = request.Name; }
            p.EnterPrisonDateTime = request.EnterPrisonDateTime;
            p.EndDateTimeSentence = request.EndDateTimeSentence;
            if (request.Cell != null) { p.Cell = request.Cell; }
            if (request.Prison != null) { p.Prison = request.Prison; }
            if (request.PrisonerType != null) { p.PrisonerType = request.PrisonerType; }
            _repository.Add(p);
            await _repository.SaveChangesAsync();

            return p;
        }
    }
}
