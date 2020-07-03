using System;

namespace FocusMark.Tasks.Domain
{
    public class UserIdMissingException : Exception
    {
        public UserIdMissingException(Guid listId)
            : base($"No list path was given for list {listId}.")
        {
            this.ListId = listId;
        }

        public UserIdMissingException(Guid listId, Exception ex)
            : base($"No list path was given for list {listId}.", ex)
        {
            this.ListId = listId;
        }

        public Guid ListId { get; }
    }
}
