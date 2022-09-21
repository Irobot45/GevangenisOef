using Gevangenis.Models.Entity;
using Gevangenis.Repositories;
using MediatR;
using Stoelendans.Contracts.Queries.Companies;

namespace Gevangenis.Application.QuerryHandlers;

internal class GetAllCellsQueryHandler : IRequestHandler<GetAllCellsQuery, IEnumerable<Cell>>
{
    private readonly IRepository<Cell> _repository;

    public GetAllCellsQueryHandler(IRepository<Cell> repository)
    {
        this._repository = repository;
    }

    public async Task<IEnumerable<Cell>> Handle(GetAllCellsQuery request, CancellationToken cancellationToken)
    {
        var cells = await _repository.GetListAsync(c => c.IsDeleted == false);
        if (cells == null)
        {
            //TODO : throw notfound exception
        }
        return cells;
    }

}
