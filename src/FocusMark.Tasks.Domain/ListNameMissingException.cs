using System;

namespace FocusMark.Tasks.Domain
{
    public class ListNameMissingException : Exception
    {
        public ListNameMissingException(Guid listId)
            : base($"No list name was given for list {listId}.")
        {
            this.ListId = listId;
        }

        public ListNameMissingException(Guid listId, Exception ex)
            : base($"No list name was given for list {listId}.", ex)
        {
            this.ListId = listId;
        }

        public Guid ListId { get; }
    }
}
