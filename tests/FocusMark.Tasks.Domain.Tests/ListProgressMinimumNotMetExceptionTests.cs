using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FocusMark.Tasks.Domain
{
    [TestClass]
    public class ListProgressMinimumNotMetExceptionTests
    {
        [TestMethod]
        [TestCategory("Tasks")]
        [TestCategory("Tasks.Domain")]
        [Owner("Johnathon Sullinger")]
        public void Constructor_GivenValue_AssignsNewValue()
        {
            // Arrange
            ListProgressMinimumNotMetException exception;
            short newValue = -1;

            // Act
            exception = new ListProgressMinimumNotMetException(newValue);

            // Assert
            Assert.AreEqual(
                newValue, 
                exception.NewValue, 
                $"Expected {nameof(newValue)} to be assigned to the {nameof(ListProgressMinimumNotMetException)}.{nameof(ListProgressMinimumNotMetException.NewValue)} property");
        }
    }
}
