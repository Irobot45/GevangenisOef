using FluentValidation;
using FluentValidation.Results;
using Gevangenis.Contracts.Commands;
using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;

namespace Gevangenis.Application.CommandHandlers
{
    public class AddPrisonCommandHandler : IRequestHandler<AddPrisonCommand, Prison>
    {
        private readonly IRepository<Prison> _repository;

        public AddPrisonCommandHandler(IRepository<Prison> repository)
        {
            this._repository = repository;
        }
        public async Task<Prison> Handle(AddPrisonCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = await new AddPrisonCommandValidator().ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            Prison p = new Prison(request.Name);
            p.AddCells(request.Cells);
            _repository.Add(p);
            await _repository.SaveChangesAsync();

            return p;
        }
    }
}
