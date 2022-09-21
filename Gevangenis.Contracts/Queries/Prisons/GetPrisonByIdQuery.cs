using Gevangenis.Contracts.Queries;
using Gevangenis.Models.Entity;

namespace Stoelendans.Contracts.Queries.Companies;

public class GetPrisonByIdQuery : QueryBase<Prison>
{
    public Guid Id { get; set; }

    public GetPrisonByIdQuery(Guid id)
    {
        Id = id;
    }
}