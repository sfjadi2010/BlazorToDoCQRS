using System.ComponentModel.DataAnnotations;

namespace BlazorToDoCQRS.Domain;

public class ToDoItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = default!;

    public string? Description { get; set; }

    public bool IsComplete { get; set; }
}
