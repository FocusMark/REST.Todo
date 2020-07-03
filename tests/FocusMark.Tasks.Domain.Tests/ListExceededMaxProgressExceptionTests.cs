using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FocusMark.Tasks.Domain
{
    [TestClass]
    public class ListExceededMaxProgressExceptionTests
    {
        [TestMethod]
        [TestCategory("Tasks")]
        [TestCategory("Tasks.Domain")]
        [Owner("Johnathon Sullinger")]
        public void Constructor_GivenValue_AssignsNewValue()
        {
            // Arrange
            ListExceededMaxProgressException exception;
            short newValue = 150;

            // Act
            exception = new ListExceededMaxProgressException(newValue);

            // Assert
            Assert.AreEqual(
                newValue, 
                exception.NewValue, 
                $"Expected {nameof(newValue)} to be assigned to the {nameof(ListExceededMaxProgressException)}.{nameof(ListExceededMaxProgressException.NewValue)} property");
        }
    }
}
