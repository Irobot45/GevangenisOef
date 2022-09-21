using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;
using Stoelendans.Contracts.Queries.Companies;

namespace Gevangenis.Application.QueryHandlers.Prisons;

public class GetPrisonByIdQueryHandler : IRequestHandler<GetPrisonByIdQuery, Prison>
{
    private readonly IRepository<Prison> _repository;

    public GetPrisonByIdQueryHandler(IRepository<Prison> repository)
    {
        _repository = repository;
    }

    public async Task<Prison> Handle(GetPrisonByIdQuery request, CancellationToken cancellationToken)
    {
        var Prison = await _repository.GetAsync(c => c.IsDeleted == false && c.Id == request.Id);
        if (Prison == null)
        {
            //TODO : throw notfound exception
        }
        return Prison;
    }
}