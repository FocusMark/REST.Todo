using System;

namespace FocusMark.Tasks.RestApi.Services.Events
{
    public class CreateTaskListEvent
    {
        public string Title { get; internal set; }
        public string Color { get; internal set; }
        public string Path { get; internal set; }
        public string Kind { get; internal set; }
        public DateTime? StartDate { get; internal set; }
        public DateTime? TargetDate { get; internal set; }
        public Guid taskListId { get; internal set; }
    }
}
