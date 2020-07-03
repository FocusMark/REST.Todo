using System;

namespace FocusMark.Tasks.Domain
{
    public class TaskListAlreadyStartedException : Exception
    {
        public TaskListAlreadyStartedException(Guid listId)
            : base($"Task List {listId}.has already started. Rebaseline the List instead.")
        {
            this.ListId = listId;
        }

        public TaskListAlreadyStartedException(Guid listId, Exception ex)
            : base($"Task List {listId}.has already started. Rebaseline the List instead.", ex)
        {
            this.ListId = listId;
        }

        public Guid ListId { get; }
    }
}
