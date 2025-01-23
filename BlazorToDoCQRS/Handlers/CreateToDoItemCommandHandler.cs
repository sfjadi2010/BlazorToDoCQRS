using BlazorToDoCQRS.Commands;
using BlazorToDoCQRS.Domain;
using BlazorToDoCQRS.Infrastructure;
using MediatR;

namespace BlazorToDoCQRS.Handlers;

public class CreateToDoItemCommandHandler(AppDbContext dbContext) : IRequestHandler<CreateToDoItemCommand, int>
{
    public async Task<int> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new ToDoItem
        {
            Title = request.Title,
            Description = request.Description,
            IsComplete = false
        };

        dbContext.ToDoItems.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
