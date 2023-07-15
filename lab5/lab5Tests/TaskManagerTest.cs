using lab5;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5;

namespace lab5Tests
{
    internal class TaskManagerTest
    {
        private TaskManager _taskManager;
        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }
        [Test]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            // Arrange
            lab5.Models.Task task = new lab5.Models.Task("Test task");
            // Act
            _taskManager.AddTask(task);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }
        [Test]
        public void RemoveTask_NonExistingTask_ShouldNotChangeTaskCount()
        {
            // Arrange
            lab5.Models.Task task = new lab5.Models.Task("Not to remove test task");
            _taskManager.AddTask(task);
            // Act
            _taskManager.RemoveTask(10);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }
        [Test]
        public void MarkTaskAsCompleted()
        {
            // Arrange
            lab5.Models.Task task = new lab5.Models.Task("Test task");
            _taskManager.AddTask(task);
            // Act
            _taskManager.MarkTaskAsCompleted(1);
            // Assert
            Assert.AreEqual(true, _taskManager.GetTaskById(1).IsCompleted);
        }
    }
}
