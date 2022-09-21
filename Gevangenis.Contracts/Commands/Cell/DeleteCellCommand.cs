using FluentValidation;
using Gevangenis.Models.Entity;

namespace Gevangenis.Contracts.Commands;

public class DeleteCellCommandValidator : AbstractValidator<DeleteCellCommand>
{
    public DeleteCellCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

public class DeleteCellCommand : CommandBase<Cell>
{
    public Guid Id { get; set; }
}