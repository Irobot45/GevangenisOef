using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;
using Stoelendans.Contracts.Queries.Companies;

namespace Gevangenis.Application.QueryHandlers.Prisoners;

public class GetPrisonerByIdQueryHandler : IRequestHandler<GetPrisonerByIdQuery, Prisoner>
{
    private readonly IRepository<Prisoner> _repository;

    public GetPrisonerByIdQueryHandler(IRepository<Prisoner> repository)
    {
        _repository = repository;
    }

    public async Task<Prisoner> Handle(GetPrisonerByIdQuery request, CancellationToken cancellationToken)
    {
        var Prisoner = await _repository.GetAsync(c => c.IsDeleted == false && c.Id == request.Id);
        if (Prisoner == null)
        {
            //TODO : throw notfound exception
        }
        return Prisoner;
    }
}