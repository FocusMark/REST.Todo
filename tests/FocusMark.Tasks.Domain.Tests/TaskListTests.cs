using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FocusMark.Tasks.Domain
{
    [TestClass]
    public class TaskListTests
    {
        [TestMethod]
        [TestCategory("Tasks")]
        [TestCategory("Tasks.Domain")]
        [Owner("Johnathon Sullinger")]
        [ExpectedException(typeof(UserIdMissingException))]
        public void Constructor_GivenNullUserId_Throws()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            _ = new TaskList(id, null);

            // Assert
            Assert.Fail("Expected exception to be thrown.");
        }

        [TestMethod]
        [TestCategory("Tasks")]
        [TestCategory("Tasks.Domain")]
        [Owner("Johnathon Sullinger")]
        [ExpectedException(typeof(InvalidListIdException))]
        public void Constructor_GivenEmptyListId_Throws()
        {
            // Arrange
            Guid id = Guid.Empty;
            string userId = Guid.NewGuid().ToString();

            // Act
            _ = new TaskList(id, userId);

            // Assert
            Assert.Fail("Expected exception to be thrown.");
        }

        [TestMethod]
        [TestCategory("Tasks")]
        [TestCategory("Tasks.Domain")]
        [Owner("Johnathon Sullinger")]
        public void Constructor_GivenId_AssignsId()
        {
            // Arrange
            TaskList entity;
            Guid id = Guid.NewGuid();
            string userId = Guid.NewGuid().ToString();

            // Act
            entity = new TaskList(id, userId);

            // Assert
            Assert.AreEqual(
                id,
                entity.TaskListId,
                $"Expected {nameof(id)} to be assigned to the {nameof(TaskList)}.{nameof(TaskList.TaskListId)} property");
        }

        [TestMethod]
        [TestCategory("Tasks")]
        [TestCategory("Tasks.Domain")]
        [Owner("Johnathon Sullinger")]
        public void Constructor_GivenUserId_AssignsId()
        {
            // Arrange
            TaskList entity;
            Guid id = Guid.NewGuid();
            string userId = Guid.NewGuid().ToString();

            // Act
            entity = new TaskList(id, userId);

            // Assert
            Assert.AreEqual(
                userId,
                entity.UserId,
                $"Expected {nameof(userId)} to be assigned to the {nameof(TaskList)}.{nameof(TaskList.UserId)} property");
        }

        [TestMethod]
        [TestCategory("Tasks")]
        [TestCategory("Tasks.Domain")]
        [Owner("Johnathon Sullinger")]
        public void ProgressTaskList_ValidAmount_SetsPercentComplete()
        {
            // Arrange
            TaskList entity;
            Guid id = Guid.NewGuid();
            string userId = Guid.NewGuid().ToString();
            byte percentAmount = 30;

            // Act
            entity = new TaskList(id, userId);
            entity.ProgressTaskList(percentAmount);

            // Assert
            Assert.AreEqual(
                percentAmount,
                entity.PercentComplete,
                $"Expected {nameof(percentAmount)} to be assigned to the {nameof(TaskList)}.{nameof(TaskList.PercentComplete)} property");
        }

        [TestMethod]
        [TestCategory("Tasks")]
        [TestCategory("Tasks.Domain")]
        [Owner("Johnathon Sullinger")]
        public void ProgressTaskList_ValidAmount_AddsPercentComplete()
        {
            // Arrange
            TaskList entity;
            Guid id = Guid.NewGuid();
            string userId = Guid.NewGuid().ToString();
            byte percentAmount1 = 30;
            byte percentAmount2 = 40;

            // Act
            entity = new TaskList(id, userId);
            entity.ProgressTaskList(percentAmount1);
            entity.ProgressTaskList(percentAmount2);

            // Assert
            Assert.AreEqual(
                percentAmount1 + percentAmount2,
                entity.PercentComplete,
                $"Expected {nameof(percentAmount1)} to be assigned to the {nameof(TaskList)}.{nameof(TaskList.PercentComplete)} property");
        }

        [TestMethod]
        [TestCategory("Tasks")]
        [TestCategory("Tasks.Domain")]
        [Owner("Johnathon Sullinger")]
        [ExpectedException(typeof(ListProgressMinimumNotMetException))]
        public void ProgressTaskList_SmallAmount_Throws()
        {
            // Arrange
            TaskList entity;
            Guid id = Guid.NewGuid();
            string userId = Guid.NewGuid().ToString();
            byte negativeAmount = 0;

            // Act
            entity = new TaskList(id, userId);
            entity.ProgressTaskList(negativeAmount);

            // Assert
            Assert.Fail("Expected exception to be thrown.");
        }

        [TestMethod]
        [TestCategory("Tasks")]
        [TestCategory("Tasks.Domain")]
        [Owner("Johnathon Sullinger")]
        public void ProgressTaskList_LargeAmount_CapsAssignmentTo100()
        {
            // Arrange
            TaskList entity;
            Guid id = Guid.NewGuid();
            string userId = Guid.NewGuid().ToString();
            byte excessPercentageAmount = 200;

            // Act
            entity = new TaskList(id, userId);
            entity.ProgressTaskList(excessPercentageAmount);

            // Assert
            Assert.AreEqual(
                TaskList.MaximumPercentCompleteAllowed,
                entity.PercentComplete,
                $"Expected {nameof(excessPercentageAmount)} to be assigned to the {nameof(TaskList)}.{nameof(TaskList.PercentComplete)} property with a capped value of 100.");
        }
    }
}
