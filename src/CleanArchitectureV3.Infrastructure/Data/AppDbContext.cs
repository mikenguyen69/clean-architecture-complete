using CleanArchitectureV3.Core.Entities;
using CleanArchitectureV3.Core.Interfaces;
using CleanArchitectureV3.Core.SharedEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitectureV3.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher) : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach(var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach(var domainEvent in events)
                {
                    _dispatcher.Dispatch(domainEvent);
                }
            }

            return result;
        }
    }
}
