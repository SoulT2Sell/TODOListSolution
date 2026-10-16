using Microsoft.EntityFrameworkCore;
using TODOListSolutionApi.DataModels;

namespace TODOListSolutionApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ToDoTask> ToDoTasks => Set<ToDoTask>();
}