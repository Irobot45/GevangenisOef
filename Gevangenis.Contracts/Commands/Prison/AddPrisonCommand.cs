using FluentValidation;
using Gevangenis.Models.Entity;

namespace Gevangenis.Contracts.Commands;

public class AddPrisonCommandValidator : AbstractValidator<AddPrisonCommand>
{
    public AddPrisonCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    } 
}

public class AddPrisonCommand : CommandBase<Prison>
{
    public string Name { get; set; } = "";
    public List<Cell> Cells { get; set; } = new List<Cell>();
}


