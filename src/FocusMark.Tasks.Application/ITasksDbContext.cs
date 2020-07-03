using FocusMark.Tasks.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FocusMark.Tasks.Application
{
    public interface ITasksDbContext
    {
        DbSet<TaskList> TaskLists { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
