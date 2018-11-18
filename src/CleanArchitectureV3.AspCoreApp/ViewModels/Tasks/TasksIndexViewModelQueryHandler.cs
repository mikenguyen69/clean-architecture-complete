using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitectureV3.AspCoreApp.Infrastructure.Mediator;
using CleanArchitectureV3.AspCoreApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureV3.AspCoreApp.ViewModels.Tasks
{
    public class TasksIndexViewModelQueryHandler : QueryHandlerBase, IRequestHandler<TasksIndexViewModelQuery, TasksIndexViewModel>
    {
        public TasksIndexViewModelQueryHandler(ToDoContext context, IMapper mapper)
            : base(context, mapper) { }

        public async Task<TasksIndexViewModel> Handle(TasksIndexViewModelQuery query, CancellationToken cancellationToken)
        {
            var model = new TasksIndexViewModel
            {
                CategoryId = query.CategoryId,
                Items = await Context.Tasks
                    .Include(x => x.Category)
                    .Where(x => !query.CategoryId.HasValue || x.Category.Id == query.CategoryId)
                    .OrderBy(x => x.Description)
                    .ProjectTo<TasksIndexViewModel.TaskListEntry>()
                    .ToListAsync()
            };

            model.CategoryOptions = new SelectList(await Context.Categories
                .OrderBy(x => x.Name)
                .ToListAsync(), "Id", "Name", model.CategoryId);

            return model;
        }
    }
}