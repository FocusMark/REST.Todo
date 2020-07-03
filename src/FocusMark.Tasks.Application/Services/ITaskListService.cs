using FocusMark.Tasks.Domain;
using System;
using System.Threading.Tasks;

namespace FocusMark.Tasks.Application.Services
{
    public interface ITaskListService
    {
        Task CreateTaskList(Guid taskListId, string title, string color, string path, Methodology kind, DateTime? startDate = null, DateTime? targetDate = null);
    }
}
