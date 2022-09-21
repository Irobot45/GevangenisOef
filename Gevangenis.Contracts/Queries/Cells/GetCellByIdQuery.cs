using Gevangenis.Contracts.Queries;
using Gevangenis.Models.Entity;

namespace Stoelendans.Contracts.Queries.Companies;

public class GetCellByIdQuery : QueryBase<Cell>
{
    public Guid Id { get; set; }

    public GetCellByIdQuery(Guid id)
    {
        Id = id;
    }
}