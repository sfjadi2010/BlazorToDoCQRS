﻿namespace BlazorToDoCQRS.Domain.Dtos;

public class ToDoItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public bool IsComplete { get; set; }
}
