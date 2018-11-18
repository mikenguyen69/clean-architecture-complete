using CleanArchitectureV3.AspCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureV3.AspCoreApp.Infrastructure.Mediator
{
    public abstract class HandlerBase
    {
        protected HandlerBase(ToDoContext context)
        {
            Context = context;
        }

        protected ToDoContext Context { get; private set; }
    }
}
