using FluentValidation;
using Gevangenis.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace Gevangenis.Contracts.Commands;

public class UpdatePrisonerCommandValidator : AbstractValidator<UpdatePrisonerCommand>
{
    public UpdatePrisonerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

public class UpdatePrisonerCommand : CommandBase<Prisoner>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime? EnterPrisonDateTime { get; set; }
    [DataType(DataType.Date)]
    public DateTime? EndDateTimeSentence { get; set; }
    [DataType(DataType.Date)]
    public DateTime? LeavePrisonDateTime { get; set; }
    public Prison? Prison { get; set; }
    public Cell? Cell { get; set; }
    public PrisonerType? PrisonerType { get; set; }
}