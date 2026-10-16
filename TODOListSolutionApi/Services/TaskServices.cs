using Microsoft.EntityFrameworkCore;
using TODOListSolutionApi.Data;
using TODOListSolutionApi.Dtos;

namespace TODOListSolutionApi.Services;

public class TaskServices : ITaskServices
{
    private readonly AppDbContext _context;
    public TaskServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskResponse>> GetTasks() => await _context.ToDoTasks.Select(x =>
        new TaskResponse
        {
            Id = x.Id,
            Name = x.Name,
            IsDone = x.IsDone,
            Description = x.Description
        }
    ).ToListAsync();

    public async Task<TaskResponse> GetTask(Guid id) => await _context.ToDoTasks.Where(x => x.Id == id).Select(x =>
        new TaskResponse
        {
            Id = x.Id,
            Name = x.Name,
            IsDone = x.IsDone,
            Description = x.Description
        }
    ).SingleAsync();

    public async Task<TaskResponse> UpdateTask(Guid id, TaskRequest updateTask)
    {
        var currentTask = await _context.ToDoTasks.Where(x => x.Id == id).SingleAsync();

        if (currentTask is null)
            return null;

        currentTask.Name = updateTask.Name;
        currentTask.IsDone = updateTask.IsDone;
        currentTask.Description = updateTask.Description;

        await _context.SaveChangesAsync();

        TaskResponse response = new()
        {
            Id = currentTask.Id,
            Name = currentTask.Name,
            IsDone = currentTask.IsDone,
            Description = currentTask.Description
        };

        return response;
    }

    public async Task<int> Deletetask(Guid id)
    {
        var task = await _context.ToDoTasks.Where(x => x.Id == id).SingleAsync();

        if (task is null)
            return 0;

        _context.ToDoTasks.Remove(task);
        await _context.SaveChangesAsync();
        return 1;
    }
}
