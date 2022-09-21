using FluentValidation;
using Gevangenis.Models.Entity;

namespace Gevangenis.Contracts.Commands;

public class UpdatePrisonCommandValidator : AbstractValidator<UpdatePrisonCommand>
{
    public UpdatePrisonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

public class UpdatePrisonCommand : CommandBase<Prison>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public List<Cell>? Cells { get; set; }
}