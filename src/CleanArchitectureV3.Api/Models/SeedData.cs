using CleanArchitectureV3.Core.Entities;
using CleanArchitectureV3.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureV3.Api.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(AppDbContext dbContext)
        {
            if (!dbContext.ToDoItems.Any())
            {
                dbContext.ToDoItems.AddRange(
                    new ToDoItem() { Id = 1, Title = "Item 1", Description = "Item 1 Description" },
                    new ToDoItem() { Id = 2, Title = "Item 2", Description = "Item 2 Description" }
                    );

                dbContext.SaveChanges();
            }
        }
    }
}
