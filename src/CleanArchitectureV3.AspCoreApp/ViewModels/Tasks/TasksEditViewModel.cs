using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureV3.AspCoreApp.ViewModels.Tasks
{
    public class TasksEditViewModel : AddOrEditSingleEntityViewModelBase
    {
        [Required(ErrorMessage ="Please provide a description")]
        [StringLength(500, ErrorMessage = "The description cannot be longer than 500 characters")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public SelectList CategoryOptions { get; set; }
    }
}
