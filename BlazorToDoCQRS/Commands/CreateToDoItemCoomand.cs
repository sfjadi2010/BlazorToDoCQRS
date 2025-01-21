namespace BlazorToDoCQRS.Commands;

public class CreateToDoItemCommand
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
}
