using MediatR;

namespace BlazorToDoCQRS.Commands;

public class CreateToDoItemCommand : IRequest<int>
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
}
