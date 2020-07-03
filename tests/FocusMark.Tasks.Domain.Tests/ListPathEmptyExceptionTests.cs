using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FocusMark.Tasks.Domain
{
    [TestClass]
    public class ListPathEmptyExceptionTests
    {
        [TestMethod]
        [TestCategory("Tasks")]
        [TestCategory("Tasks.Domain")]
        [Owner("Johnathon Sullinger")]
        public void Constructor_GivenId_AssignsId()
        {
            // Arrange
            ListPathEmptyException exception;
            Guid id = Guid.NewGuid();

            // Act
            exception = new ListPathEmptyException(id);

            // Assert
            Assert.AreEqual(
                id, 
                exception.ListId, 
                $"Expected {nameof(id)} to be assigned to the {nameof(ListPathEmptyException)}.{nameof(ListPathEmptyException.ListId)} property");
        }
    }
}
