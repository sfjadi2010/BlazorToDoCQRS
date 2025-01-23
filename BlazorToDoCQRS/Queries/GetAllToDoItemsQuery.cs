using BlazorToDoCQRS.Domain;
using MediatR;

namespace BlazorToDoCQRS.Queries;

public class GetAllToDoItemsQuery : IRequest<List<ToDoItem>>
{
}
