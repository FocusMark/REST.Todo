using System;

namespace FocusMark.Tasks.Domain
{
    public class InvalidTaskListColor : Exception
    {
        public InvalidTaskListColor(Guid listId, string newColor, string expectedPattern)
            : base($"The {newColor} color for Task List {listId} does not match the expected pattern of {expectedPattern}.")
        {
            this.ListId = listId;
            this.NewColor = newColor;
            this.ExpectedPattern = expectedPattern;
        }

        public InvalidTaskListColor(Guid listId, string newColor, string expectedPattern, Exception ex)
            : base($"The {newColor} color for Task List {listId} does not match the expected pattern of {expectedPattern}.", ex)
        {
            this.ListId = listId;
            this.NewColor = newColor;
            this.ExpectedPattern = expectedPattern;
        }

        public Guid ListId { get; }

        public string NewColor { get; }

        public string ExpectedPattern { get; }
    }
}
