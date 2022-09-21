using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;
using Stoelendans.Contracts.Queries.Companies;

namespace Gevangenis.Application.QueryHandlers.Cells;

public class GetCellByIdQueryHandler : IRequestHandler<GetCellByIdQuery, Cell>
{
    private readonly IRepository<Cell> _repository;

    public GetCellByIdQueryHandler(IRepository<Cell> repository)
    {
        _repository = repository;
    }

    public async Task<Cell> Handle(GetCellByIdQuery request, CancellationToken cancellationToken)
    {
        var Cell = await _repository.GetAsync(c => c.IsDeleted == false && c.Id == request.Id);
        if (Cell == null)
        {
            //TODO : throw notfound exception
        }
        return Cell;
    }
}