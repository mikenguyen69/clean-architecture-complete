using CleanArchitectureV3.AspCoreApp.Infrastructure.Mediator;
using CleanArchitectureV3.AspCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureV3.AspCoreApp.Commands.Tasks
{
    public abstract class SingleTaskCommandHandlerBase : CommandHandlerBase
    {
        protected SingleTaskCommandHandlerBase(ToDoContext context) : base(context) { }

        protected async Task<Models.Task> GetTask(int id)
        {
            var task = await Context.Tasks.SingleOrDefaultAsync(x => x.Id == id);

            if (task == null)
            {
                throw new NullReferenceException($"Task with id: {id} not found.");
            }

            return task;
        }
    }
}
