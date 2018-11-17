using CleanArchitectureV3.Core.Interfaces;
using CleanArchitectureV3.Core.SharedEntity;
using CleanArchitectureV3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureV3.Tests.Integration.Data
{
    public class BaseRepositorySetup<T> where T: BaseEntity
    {
        protected AppDbContext _dbContext;
        protected EfRepository<T> _repository;

        public BaseRepositorySetup()
        {
            var options = CreateNewContextOptions();
            var mockDispatcher = new Mock<IDomainEventDispatcher>();
            _dbContext = new AppDbContext(options, mockDispatcher.Object);
            _repository = new EfRepository<T>(_dbContext);
        }

        private DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("cleanarchitecture")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}
