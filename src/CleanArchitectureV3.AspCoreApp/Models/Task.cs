using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureV3.AspCoreApp.Models
{
    public class Task
    {
        private Task() { }

        public Task(string description, Category category)
        {
            SetDetails(description, category);
        }

        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; private set; }

        public bool IsComplete { get; private set; }

        public void SetDetails(string description, Category category)
        {
            throw new NotImplementedException();
        }

        public void MarkComplete()
        {
            IsComplete = true;
        }

        public void MarkIncomplete()
        {
            IsComplete = false;
        }
    }
}
