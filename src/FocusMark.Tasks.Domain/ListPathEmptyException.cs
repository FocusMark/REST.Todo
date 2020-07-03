using System;

namespace FocusMark.Tasks.Domain
{
    public class ListPathEmptyException : Exception
    {
        public ListPathEmptyException(Guid listId)
            : base($"No list path was given for list {listId}.")
        {
            this.ListId = listId;
        }

        public ListPathEmptyException(Guid listId, Exception ex)
            : base($"No list path was given for list {listId}.", ex)
        {
            this.ListId = listId;
        }

        public Guid ListId { get; }
    }
}
