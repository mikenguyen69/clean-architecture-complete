using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureV3.AspCoreApp.ViewModels.Tasks
{
    public class TasksIndexViewModelQuery : IRequest<TasksIndexViewModel> 
    {
        public int? CategoryId { get; set; }
    }
}
