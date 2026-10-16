namespace TODOListSolutionApi.Dtos;

public record class TaskRequest
{
        public required string Name { get; set; }
        public bool IsDone { get; set; } = false;
        public string Description { get; set; } = string.Empty; 
}
