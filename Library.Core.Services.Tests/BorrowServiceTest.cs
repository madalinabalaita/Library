using System;
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
    public class BorrowServiceTest
    {
        private static IEnumerable<Borrow> GetBorrows()
        {
            return new List<Borrow>
            {
                new Borrow
                {
                    Id=700,
                    Since=new DateTime(2020,05,22),
                    Until=new DateTime(2020,06,22),
                    LibrarySubscription=new LibrarySubscription
                    {
                        Id=-7,
                        Created=new DateTime(2012,07,09),
                        Fees=1M
                    }
                },
                 new Borrow
                {
                    Id=701,
                    Since=new DateTime(2020,07,01),
                    Until=new DateTime(2020,08,02),
                    LibrarySubscription=new LibrarySubscription
                    {
                        Id=100,
                        Created=new DateTime(2015,11,11),
                        Fees=0M
                    }
                }
            };
        }
      [Test]
      public void Add_Borrow()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase("Add_writes_to_database")
                .Options;

            using(var context=new LibraryDbContext(options))
            {
                var service = new BorrowService(context);
                service.Add(new Borrow
                {
                    Id = -10
                });
                Assert.AreEqual(-10, context.Borrows.Single().Id);
            }
        }
    }
}
