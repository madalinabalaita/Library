using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Library.Data;
using Library.Data.Models;
using Library.Core.Services;
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

        [Test]
        public void Get_All_Items()
        {
            var mockSet = Build();
            var mockC = new Mock<LibraryDbContext>();
            mockC.Setup(i => i.LibraryItems).Returns(mockSet.Object);

            var s = new LibraryItemService(mockC.Object);
            var queryRes = s.GetAll().ToList();

            queryRes.Should().AllBeAssignableTo(typeof(LibraryItem));
            queryRes.Should().HaveCount(2);
            queryRes.Should().Contain(i => i.Title == "1Q84");
        }
        [Test]
        public void Get_Item_By_Id()
        {
            var mockSet = Build();

            var mockCtx = new Mock<LibraryDbContext>();
            mockCtx.Setup(c => c.LibraryItems).Returns(mockSet.Object);

            var sut = new LibraryItemService(mockCtx.Object);
            var queryResult = sut.GetById(230);
            var expected = new Movie
            {
                Id = 230,
                Title = "Black Swan",
                Director = "Darren Aronofsky"
            };

            queryResult.Should().BeEquivalentTo(expected);
        }
        [Test]
        public void Get_Items_Title()
        {
            var mockSet = Build();

            var mockCtx = new Mock<LibraryDbContext>();
            mockCtx.Setup(c => c.LibraryItems).Returns(mockSet.Object);

            var sut = new LibraryItemService(mockCtx.Object);
            var queryResult = sut.GetTitle(234);
            queryResult.Should().Be("Black Swan");
        }
        [Test]
        public void Get_Items_Type_Given_Book()
        {
            var mockSet = Build();

            var mockCtx = new Mock<LibraryDbContext>();
            mockCtx.Setup(c => c.LibraryItems).Returns(mockSet.Object);

            var sut = new LibraryItemService(mockCtx.Object);
            var queryResult = sut.GetType(200);
            queryResult.Should().Be("Book");
        }
        [Test]
        public void Get_Asset_Type_Given_Video()
        {
            var mockSet = Build();

            var mockCtx = new Mock<LibraryDbContext>();
            mockCtx.Setup(c => c.LibraryItems).Returns(mockSet.Object);

            var sut = new LibraryItemService(mockCtx.Object);
            var queryResult = sut.GetType(230);
            queryResult.Should().Be("Video");
        }
        [Test]
        public void Get_Author_Given_Book()
        {
            var mockSet = Build();

            var mockCtx = new Mock<LibraryDbContext>();
            mockCtx.Setup(c => c.LibraryItems).Returns(mockSet.Object);

            var sut = new LibraryItemService(mockCtx.Object);
            var queryResult = sut.GetAOD(200);
            queryResult.Should().Be("Haruki Murakami");
        }
    }

}
