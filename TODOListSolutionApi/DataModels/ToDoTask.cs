namespace TODOListSolutionApi.DataModels;

public class ToDoTask
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public bool IsDone { get; set; } = false;
    public string? Description { get; set; }
}