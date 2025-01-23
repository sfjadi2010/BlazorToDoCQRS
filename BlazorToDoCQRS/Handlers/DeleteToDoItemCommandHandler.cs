using BlazorToDoCQRS.Commands;
using BlazorToDoCQRS.Infrastructure;
using MediatR;

namespace BlazorToDoCQRS.Handlers;

public class DeleteToDoItemCommandHandler(AppDbContext dbContext) : IRequestHandler<DeleteToDoItemCommand, Unit>
{
    public async Task<Unit> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.ToDoItems.FindAsync([request.Id], cancellationToken);

        if (entity is null)
        {
            return Unit.Value;
        }

        dbContext.ToDoItems.Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
