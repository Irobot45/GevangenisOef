using FluentValidation;
using Gevangenis.Models.Entity;

namespace Gevangenis.Contracts.Commands;

public class DeletePrisonCommandValidator : AbstractValidator<DeletePrisonCommand>
{
    public DeletePrisonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    } 
}

public class DeletePrisonCommand : CommandBase<Prison>
{
    public Guid Id { get; set; }
}