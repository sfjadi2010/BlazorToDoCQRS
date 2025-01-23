using BlazorToDoCQRS.Commands;
using BlazorToDoCQRS.Infrastructure;
using MediatR;

namespace BlazorToDoCQRS.Handlers;

public class UpdateToDoItemCommandHandler(AppDbContext dbContext) : IRequestHandler<UpdateToDoItemCommand, Unit>
{
    public async Task<Unit> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.ToDoItems.FindAsync([request.Id], cancellationToken);

        if (entity is null)
        {
            return Unit.Value;
        }

        entity.Title = request.Title;
        entity.Description = request.Description;
        entity.IsComplete = request.IsComplete;

        dbContext.Update(entity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
