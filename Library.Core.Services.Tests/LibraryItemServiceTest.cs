using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Library.Data;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Library.Core.Services.Tests
{
    [TestFixture]
    class LibraryItemServiceTest
    {
       private static IEnumerable<LibraryItem> GetItems(){
            return new List<LibraryItem>
            {
                new Book
                {
                    Id=200,
                    Title="1Q84",
                    Author="Haruki Murakami",
                    DeweyNr="800.888"
                },
                new Movie
                {
                    Id=230,
                    Title="Black Swan",
                    Director="Darren Aronofsky"
                }
            };
        }
        private Mock<DbSet<LibraryItem>> Build()
        {
            var items = GetItems().AsQueryable();
            var mock = new Mock<DbSet<LibraryItem>>();
            mock.As<IQueryable<LibraryItem>>().Setup(i => i.Provider).Returns(items.Provider);
            mock.As<IQueryable<LibraryItem>>().Setup(i => i.Expression).Returns(items.Expression);
            mock.As<IQueryable<LibraryItem>>().Setup(i => i.ElementType).Returns(items.ElementType);
            mock.As<IQueryable<LibraryItem>>().Setup(i => i.GetEnumerator()).Returns(items.GetEnumerator());
            return mock;
        }
        
        [Test]
        public void Add_new_Item()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase("Add_item_writes_to_db").Options;
            using( var context= new LibraryDbContext(options))
            {
                var service = new LibraryItemService(context);
                service.Add(new Book
                {
                    Id = -5
                });
                Assert.AreEqual(-5, context.LibraryItems.Single().Id);
            }
        }

    }

}
