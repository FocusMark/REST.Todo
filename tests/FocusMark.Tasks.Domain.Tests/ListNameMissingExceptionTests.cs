using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FocusMark.Tasks.Domain
{
    [TestClass]
    public class ListNameMissingExceptionTests
    {
        [TestMethod]
        [TestCategory("Tasks")]
        [TestCategory("Tasks.Domain")]
        [Owner("Johnathon Sullinger")]
        public void Constructor_GivenId_AssignsId()
        {
            // Arrange
            ListNameMissingException exception;
            Guid id = Guid.NewGuid();

            // Act
            exception = new ListNameMissingException(id);

            // Assert
            Assert.AreEqual(
                id, 
                exception.ListId, 
                $"Expected {nameof(id)} to be assigned to the {nameof(ListNameMissingException)}.{nameof(ListNameMissingException.ListId)} property");
        }
    }
}
