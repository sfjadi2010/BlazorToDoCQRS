using BlazorToDoCQRS.Domain;
using MediatR;

namespace BlazorToDoCQRS.Queries;

public class GetToDoItemByIdQuery(int id) : IRequest<ToDoItem>
{
    public int Id { get; set; } = id;
}
