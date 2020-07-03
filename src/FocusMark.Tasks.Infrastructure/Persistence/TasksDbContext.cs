using FocusMark.Tasks.Application;
using FocusMark.Tasks.Domain;
using Microsoft.EntityFrameworkCore;

namespace FocusMark.Tasks.Infrastructure.Persistence
{
    public class TasksDbContext : DbContext, ITasksDbContext
    {
        public TasksDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskList> TaskLists { get; set; }
    }
}
