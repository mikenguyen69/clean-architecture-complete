using CleanArchitectureV3.Core.Events;
using CleanArchitectureV3.Core.SharedEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureV3.Core.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public void MarkComplete()
        {
            IsDone = true;
            Events.Add(new ToDoItemCompletedEvent(this));
        }
    }
}
