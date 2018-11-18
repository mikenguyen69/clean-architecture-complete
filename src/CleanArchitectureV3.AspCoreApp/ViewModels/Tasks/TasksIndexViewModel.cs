using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureV3.AspCoreApp.ViewModels.Tasks
{
    public class TasksIndexViewModel : ListViewModelBase<TasksIndexViewModel.TaskListEntry>
    {
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        public SelectList CategoryOptions { get; set; }

        public class TaskListEntry
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public bool IsComplete { get; set; }
            public string CategoryName { get; set; }
        }
    }
}
