using Gevangenis.Contracts.Queries;
using Gevangenis.Models.Entity;

namespace Stoelendans.Contracts.Queries.Companies;

public class GetPrisonerByIdQuery : QueryBase<Prisoner>
{
    public Guid Id { get; set; }

    public GetPrisonerByIdQuery(Guid id)
    {
        Id = id;
    }
}