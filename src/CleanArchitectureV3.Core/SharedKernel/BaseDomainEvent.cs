using System;

namespace CleanArchitectureV3.Core.SharedEntity
{
    public abstract class BaseDomainEvent
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.Now;
    }
}