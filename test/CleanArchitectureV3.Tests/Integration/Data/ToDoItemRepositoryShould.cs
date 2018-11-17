using CleanArchitectureV3.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CleanArchitectureV3.Tests.Integration.Data
{
    public class ToDoItemRepositoryShould : BaseRepositorySetup<ToDoItem>
    {
        [Fact]
        public void AddItemAndSetId()
        {
            var item = AddItemWithInitialTitle();

            var newItem = _repository.List().FirstOrDefault();

            Assert.Equal(item, newItem);
            Assert.True(newItem.Id > 0);
        }

        [Fact]
        public void UpdateItemAfterAddingIt()
        {
            var item = AddItemWithInitialTitle();

            // Gold : update need to detach state
            _dbContext.Entry(item).State = EntityState.Detached;

            var newItem = _repository.List().FirstOrDefault();
            newItem.Title = Guid.NewGuid().ToString();
            _repository.Update(newItem);

            Assert.NotEqual(item.Title, newItem.Title);
            Assert.Equal(item.Id, newItem.Id);
        }

        [Fact]
        public void DeleteItemAfterAddingIt()
        {
            var item = AddItemWithInitialTitle();
            _repository.Delete(item);

            Assert.DoesNotContain(_repository.List(), i => i.Title == item.Title);
        }

        private ToDoItem AddItemWithInitialTitle()
        {
            var initialTitle = Guid.NewGuid().ToString();
            var item = new ToDoItem()
            {
                Title = initialTitle
            };
            _repository.Add(item);

            return item ;
        }
    }
}
