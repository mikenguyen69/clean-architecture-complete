using CleanArchitectureV3.Core.SharedEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureV3.Core.Interfaces
{
    public interface IHandler<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}
