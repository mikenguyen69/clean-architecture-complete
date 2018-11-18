using AutoMapper;
using CleanArchitectureV3.AspCoreApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureV3.AspCoreApp.ViewModels.Tasks
{
    public class TasksEditViewModelQueryHandler : SingleTaskQueryHandlerBase, IRequestHandler<TasksEditViewModelQuery, TasksEditViewModel>
    {
        public TasksEditViewModelQueryHandler(ToDoContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<TasksEditViewModel> Handle(TasksEditViewModelQuery query, CancellationToken cancellationToken)
        {
            var model = new TasksEditViewModel();
            if (query.Id > 0)
            {
                var task = await GetTask(query.Id);
                Mapper.Map(task, model);
            }

            model.CategoryOptions = new SelectList(await Context.Categories
                .OrderBy(x => x.Name)
                .ToListAsync(), "Id", "Name", model.CategoryId);

            return model;
        }
        
    }
}
