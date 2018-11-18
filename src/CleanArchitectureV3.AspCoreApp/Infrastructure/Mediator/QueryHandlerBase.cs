using AutoMapper;
using CleanArchitectureV3.AspCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureV3.AspCoreApp.Infrastructure.Mediator
{
    public abstract class QueryHandlerBase : HandlerBase
    {
        protected QueryHandlerBase(ToDoContext context, IMapper mapper) : base(context)
        {
            Mapper = mapper;
        }

        protected IMapper Mapper { get; private set; }
    }
}
