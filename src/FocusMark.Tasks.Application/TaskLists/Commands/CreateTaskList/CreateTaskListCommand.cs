using FocusMark.Tasks.Domain;
using MediatR;
using System;

namespace FocusMark.Tasks.Application.TasksLists.Commands
{
    public class CreateTaskListCommand : IRequest<Guid>
    {
        public string Title { get; set; }

        // Create a default hex color
        public string Color { get; set; } = $"#{new Random().Next(0x1000000):X6}";

        public string Path { get; set; } = "/";

        public string Kind { get; set; } = Methodology.Kanban.ToString();

        public DateTime? StartDate { get; set; }

        public DateTime? TargetDate { get; set; }
    }
}
