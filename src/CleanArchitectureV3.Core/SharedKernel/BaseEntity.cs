using System.Collections.Generic;

namespace CleanArchitectureV3.Core.SharedEntity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}