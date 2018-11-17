using Ardalis.GuardClauses;
using CleanArchitectureV3.Core.Events;
using CleanArchitectureV3.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureV3.Core.Services
{
    public class ToDoItemService : IHandler<ToDoItemCompletedEvent>
    {
        public void Handle(ToDoItemCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));
        }
    }
}
