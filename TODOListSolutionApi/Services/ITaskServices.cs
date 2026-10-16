using System;
using TODOListSolutionApi.Dtos;

namespace TODOListSolutionApi.Services;

public interface ITaskServices
{
    Task<int> Deletetask(Guid id);
    Task<TaskResponse> GetTask(Guid id);
    Task<List<TaskResponse>> GetTasks();
    Task<TaskResponse> UpdateTask(Guid id, TaskRequest updateTask);
}
