using FluentValidation;
using Gevangenis.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace Gevangenis.Contracts.Commands;

public class AddPrisonerCommandValidator : AbstractValidator<AddPrisonerCommand>
{
    public AddPrisonerCommandValidator()
    {
        RuleFor(c => c.Name).NotNull().NotEmpty();
        RuleFor(c => c.Prison).NotNull().NotEmpty();
        RuleFor(c => c.Cell).NotNull().NotEmpty();
    } 
}

public class AddPrisonerCommand : CommandBase<Prisoner>
{
    public string Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime EnterPrisonDateTime { get; set; } = DateTime.Now;
    [DataType(DataType.Date)]
    public DateTime EndDateTimeSentence { get; set; } = DateTime.MaxValue;
    public Prison Prison { get; set; }
    public Cell Cell { get; set; }
    public PrisonerType PrisonerType { get; set; } = PrisonerType.lowLevel;
}


