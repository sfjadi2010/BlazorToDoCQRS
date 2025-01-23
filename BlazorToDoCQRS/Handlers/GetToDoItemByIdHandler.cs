using BlazorToDoCQRS.Domain;
using BlazorToDoCQRS.Infrastructure;
using BlazorToDoCQRS.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorToDoCQRS.Handlers;

public class GetToDoItemByIdHandler(AppDbContext dbContext) : IRequestHandler<GetToDoItemByIdQuery, ToDoItem?>
{
    public async Task<ToDoItem?> Handle(GetToDoItemByIdQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    }
}
