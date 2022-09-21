using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;
using Stoelendans.Contracts.Queries.Companies;

namespace Gevangenis.Application.QuerryHandlers.Companies;

internal class GetAllPrisonsQueryHandler : IRequestHandler<GetAllPrisonsQuery, IEnumerable<Prison>>
{
    private readonly IRepository<Prison> _repository;

    public GetAllPrisonsQueryHandler(IRepository<Prison> repository)
    {
        this._repository = repository;
    }

    public async Task<IEnumerable<Prison>> Handle(GetAllPrisonsQuery request, CancellationToken CancellationToken)
    {
        var Prisons = await _repository.GetListAsync(c => c.IsDeleted == false);
        if (Prisons == null)
        {
            //TODO : throw notfound exception
        }
        return Prisons;
    }

}
