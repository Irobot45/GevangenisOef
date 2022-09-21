using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;
using Stoelendans.Contracts.Queries.Companies;

namespace Gevangenis.Application.QuerryHandlers.Companies;

internal class GetAllPrisonersQueryHandler : IRequestHandler<GetAllPrisonersQuery, IEnumerable<Prisoner>>
{
    private readonly IRepository<Prisoner> _repository;

    public GetAllPrisonersQueryHandler(IRepository<Prisoner> repository)
    {
        this._repository = repository;
    }

    public async Task<IEnumerable<Prisoner>> Handle(GetAllPrisonersQuery request, CancellationToken CancellationToken)
    {
        var Prisoners = await _repository.GetListAsync(c => c.IsDeleted == false);
        if (Prisoners == null)
        {
            throw new FileNotFoundException("Prisoner not found");
        }
        return Prisoners;
    }

}
