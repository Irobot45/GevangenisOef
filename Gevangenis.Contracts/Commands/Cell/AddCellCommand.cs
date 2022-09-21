using FluentValidation;
using Gevangenis.Models.Entity;

namespace Gevangenis.Contracts.Commands;

public class AddCellCommandValidator : AbstractValidator<AddCellCommand>
{
    public AddCellCommandValidator()
    {
        RuleFor(c => c.Prison).NotNull().NotEmpty();
    } 
}

public class AddCellCommand : CommandBase<Cell>
{
    public int Capacity { get; set; } = 1;
    public bool IsIsolationCell { get; set; } = false;
    public Prison Prison { get; set; }
    public List<Prisoner> Prisoners { get; set; } = new List<Prisoner>();
}


