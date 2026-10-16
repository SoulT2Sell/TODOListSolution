using System;

namespace TODOListSolutionApi.Dtos;

public class TaskResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public bool IsDone { get; set; } = false;
    public string Description { get; set; } = string.Empty; 
}
