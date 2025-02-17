﻿using MediatR;

namespace BlazorToDoCQRS.Commands;

public class UpdateToDoItemCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public bool IsComplete { get; set; }
}
