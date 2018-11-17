using CleanArchitectureV3.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureV3.Tests.Integration.Api
{
    public class ToDoItemControllerTest : BaseWebControllerTest<ToDoItem>
    {
        [Fact]
        public async Task ListShouldReturnTwoItems()
        {
            var result = (await GetList("/api/todoitems")).ToList();
            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.Count(x => x.Title == "Item 1"));
            Assert.Equal(1, result.Count(x => x.Title == "Item 2"));
        }

        [Fact]
        public async Task GetByIdShouldReturnOneItem()
        {
            var result = (await GetById("/api/todoitems/1"));
            Assert.NotNull(result);
            Assert.Equal("Item 1", result.Title);
        }

        [Fact]
        public async Task PostShouldAddNewItem()
        {
            var newItem = new ToDoItem
            {
                Id = 3, 
                Title = "Item 3",
                Description = "Item 3 description"
            };

            await (Post("/api/todoitems", newItem));

            var result = (await GetById("/api/todoitems/3"));
            Assert.NotNull(result);
            Assert.Equal("Item 3", result.Title);
        }

        [Fact]
        public async Task CompleteShouldMarkItemToBeDone()
        {
            var result = (await GetById("/api/todoitems/1/complete"));
            Assert.NotNull(result);
            Assert.Equal("Item 1", result.Title);
            Assert.True(result.IsDone);
        }

        [Fact]
        public async Task CompleteByPatchShouldAlsoMarkItemToBeDone()
        {
            var result = await GetById("/api/todoitems/1");
            var response = await Patch("/api/todoitems/complete", result);
            Assert.Equal(response.Id, result.Id);
            Assert.Equal(response.Title, result.Title);
            Assert.True(response.IsDone);
        }
    }
}
