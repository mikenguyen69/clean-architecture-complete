using CleanArchitectureV3.Core.Entities;
using CleanArchitectureV3.Core.SharedEntity;

namespace CleanArchitectureV3.Core.Events
{
    public class ToDoItemCompletedEvent : BaseDomainEvent
    {
        private ToDoItem completedItem;

        public ToDoItemCompletedEvent(ToDoItem toDoItem)
        {
            this.completedItem = toDoItem;
        }
    }
}