using AutoMapper;
using CleanArchitectureV3.AspCoreApp.Infrastructure.Mediator;
using CleanArchitectureV3.AspCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CleanArchitectureV3.AspCoreApp.ViewModels.Tasks
{
    public abstract class SingleTaskQueryHandlerBase : QueryHandlerBase
    {
        protected SingleTaskQueryHandlerBase(ToDoContext context, IMapper mapper) : base(context, mapper) { }

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
