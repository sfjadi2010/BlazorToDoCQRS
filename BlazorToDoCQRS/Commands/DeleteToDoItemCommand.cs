using MediatR;

namespace BlazorToDoCQRS.Commands;

public class DeleteToDoItemCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; }
}
