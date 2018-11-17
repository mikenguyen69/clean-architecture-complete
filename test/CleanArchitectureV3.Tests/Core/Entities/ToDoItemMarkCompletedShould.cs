using CleanArchitectureV3.Core.Entities;
using CleanArchitectureV3.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CleanArchitectureV3.Tests.Core.Entities
{
    public class ToDoItemMarkCompletedShould
    {
        [Fact]
        public void SetIsDoneToTrue()
        {
            var item = new ToDoItem();
            item.MarkComplete();

            Assert.True(item.IsDone);
        }

        [Fact]
        public void RaiseToDoItemCompletedEvent()
        {
            var item = new ToDoItem();
            item.MarkComplete();

            Assert.Single(item.Events);
            Assert.IsType<ToDoItemCompletedEvent>(item.Events.First());
        }
    }
}
