using BlazorToDoCQRS.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorToDoCQRS.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<ToDoItem> ToDoItems { get; set; } = default!;
}
