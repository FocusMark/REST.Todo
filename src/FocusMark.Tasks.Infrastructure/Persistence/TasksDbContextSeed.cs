using FocusMark.Tasks.Domain;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FocusMark.Tasks.Infrastructure.Persistence
{
    public static class TasksDbContextSeed
    {
        public static async Task SeedSampleDataAsync(TasksDbContext context)
        {
            if (!context.TaskLists.Any())
            {
                for (int count = 0; count < 10; count++)
                {
                    var taskList = new TaskList(Guid.NewGuid(), string.Empty);

                    taskList.ConvertToKanbanTaskList();
                    taskList.MoveTaskList("/home");
                    taskList.ProgressTaskList(15);
                    taskList.RebaselineTaskList(DateTime.UtcNow);
                    taskList.RenameTaskList("My Projects");
                    taskList.StartPlanning();

                    context.TaskLists.Add(taskList);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
