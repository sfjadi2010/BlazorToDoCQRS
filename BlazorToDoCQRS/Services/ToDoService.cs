using BlazorToDoCQRS.Commands;
using BlazorToDoCQRS.Domain;
using BlazorToDoCQRS.Infrastructure;
using BlazorToDoCQRS.Queries;
using Microsoft.EntityFrameworkCore;

namespace BlazorToDoCQRS.Services;

public class ToDoService(AppDbContext appDbContext)
{
    // Queryies
    public async Task<List<ToDoItem>> Handle(GetAllToDoItemsQuery query)
    {
        return await appDbContext.ToDoItems
            .OrderByDescending(x => x.Id)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ToDoItem?> Handle(GetToDoItemByIdQuery query)
    {
        return await appDbContext.ToDoItems
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == query.Id);
    }

    // Commands
    public async Task<int> Handle(CreateToDoItemCommand command)
    {
        var toDoItem = new ToDoItem
        {
            Title = command.Title,
            Description = command.Description,
            IsComplete = false
        };

        appDbContext.ToDoItems.Add(toDoItem);
        await appDbContext.SaveChangesAsync();
        return toDoItem.Id;
    }

    public async Task Handle(UpdateToDoItemCommand command)
    {
        var toDoItem = await appDbContext.ToDoItems
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == command.Id);

        if (toDoItem == null)
            throw new Exception("ToDo item not found");

        toDoItem.Title = command.Title;
        toDoItem.Description = command.Description;
        toDoItem.IsComplete = command.IsComplete;
        appDbContext.Update(toDoItem);
        await appDbContext.SaveChangesAsync();
    }

    public async Task Handle(DeleteToDoItemCommand command)
    {
        var toDoItem = await appDbContext.ToDoItems
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == command.Id);

        if (toDoItem == null)
            throw new Exception("ToDo item not found");

        appDbContext.ToDoItems.Remove(toDoItem);
        await appDbContext.SaveChangesAsync();
    }
}
