using FluentValidation;
using Gevangenis.Models.Entity;

namespace Gevangenis.Contracts.Commands;

public class DeletePrisonerCommandValidator : AbstractValidator<DeletePrisonerCommand>
{
    public DeletePrisonerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

public class DeletePrisonerCommand : CommandBase<Prisoner>
{
    public Guid Id { get; set; }
}