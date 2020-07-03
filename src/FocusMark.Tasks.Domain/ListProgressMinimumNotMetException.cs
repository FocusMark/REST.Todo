using System;

namespace FocusMark.Tasks.Domain
{
    public class ListProgressMinimumNotMetException : Exception
    {
        public ListProgressMinimumNotMetException(short newValue)
            : base($"The value of {newValue} does not meet the minimum allowed progression.")
        {
            this.NewValue = newValue;
        }

        public ListProgressMinimumNotMetException(short newValue, Exception ex)
            : base($"The value of {newValue} does not meet the minimum allowed progression.", ex)
        {
            this.NewValue = newValue;
        }

        public short NewValue { get; }
    }
}
