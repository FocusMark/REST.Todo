using System;

namespace FocusMark.Tasks.Domain
{
    public class ListExceededMaxProgressException : Exception
    {
        public ListExceededMaxProgressException(short newValue)
    : base($"The value of {newValue} exceeds the allowed progression amount allowed.")
        {
            this.NewValue = newValue;
        }

        public ListExceededMaxProgressException(short newValue, Exception ex)
            : base($"The value of {newValue} exceeds the allowed progression amount allowed.", ex)
        {
            this.NewValue = newValue;
        }

        public short NewValue { get; }
    }
}
