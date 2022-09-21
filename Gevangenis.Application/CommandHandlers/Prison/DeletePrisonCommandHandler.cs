using FluentValidation;
using FluentValidation.Results;
using Gevangenis.Contracts.Commands;
using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;

namespace Gevangenis.Application.CommandHandlers
{
    public class DeletePrisonCommandHandler : IRequestHandler<DeletePrisonCommand, Prison>
    {
        private readonly IRepository<Prison> _repository;

        public DeletePrisonCommandHandler(IRepository<Prison> repository)
        {
            this._repository = repository;
        }
        public async Task<Prison> Handle(DeletePrisonCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await new DeletePrisonCommandValidator().ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            Prison p = await _repository.GetAsync(p => p.Id == request.Id && p.IsDeleted == false);
            _repository.Delete(p);
            await _repository.SaveChangesAsync();

            return p;
        }
    }
}
