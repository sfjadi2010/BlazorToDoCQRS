using BlazorToDoCQRS.Domain;
using BlazorToDoCQRS.Infrastructure;
using BlazorToDoCQRS.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorToDoCQRS.Handlers;

public class GetAllToDoItemsHandler(AppDbContext dbContext) : IRequestHandler<GetAllToDoItemsQuery, List<ToDoItem>>
{
    public async Task<List<ToDoItem>> Handle(GetAllToDoItemsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.ToDoItems
            .AsNoTracking()
            .OrderByDescending(x => x.Id)
            .ToListAsync(cancellationToken);
    }
}
