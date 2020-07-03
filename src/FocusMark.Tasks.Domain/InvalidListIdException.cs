using System;

namespace FocusMark.Tasks.Domain
{
    public class InvalidListIdException : Exception
    {
        public InvalidListIdException(Guid listId)
            : base($"The {nameof(listId)} provided of {listId} is not valid.")
        {
            this.ListId = listId;
        }

        public InvalidListIdException(Guid listId, Exception ex)
            : base($"The {nameof(listId)} provided of {listId} is not valid.", ex)
        {
            this.ListId = listId;
        }

        public Guid ListId { get; }
    }
}
