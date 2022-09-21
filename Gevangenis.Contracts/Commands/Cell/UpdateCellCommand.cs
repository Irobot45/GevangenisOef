using FluentValidation;
using Gevangenis.Models.Entity;

namespace Gevangenis.Contracts.Commands;

public class UpdateCellCommandValidator : AbstractValidator<UpdateCellCommand>
{
    public UpdateCellCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

public class UpdateCellCommand : CommandBase<Cell>
{
    public Guid Id { get; set; }
    public int? Capacity { get; set; }
    public bool? IsIsolationCell { get; set; }
    public Prison? Prison { get; set; }
    public List<Prisoner>? Prisoners { get; set; }
}