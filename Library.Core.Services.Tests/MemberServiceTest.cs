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
{   [TestFixture]
    class MemberServiceTest
    {
        private static IEnumerable<Member> GetMembers()
        {
            return new List<Member>
            {
                new Member
                {
                    Id=15,
                    FirstName="Georgiana",
                    LastName="Popescu",
                    PhoneNr="2000220201",
                    Address="Str. Trandafirilor nr 5",
                    DateOfBirth=new DateTime(1998,11,10)
                },
                  new Member
                {
                    Id=16,
                    FirstName="George",
                    LastName="Calinescu",
                    PhoneNr="2000220202",
                    Address="Str. Norilor nr 6",
                    DateOfBirth=new DateTime(1970,06,16)
                },
                    new Member
                {
                    Id=17,
                    FirstName="Catalin-Ioan",
                    LastName="Georgescu",
                    PhoneNr="2000220203",
                    Address="Str. Zapezii nr 7",
                    DateOfBirth=new DateTime(1964,01,01)
                }
            };
        }
        [Test]
        public void Add_Member()
        {
            var mock = new Mock<DbSet<Member>>();
            var mockContext = new Mock<LibraryDbContext>();

            mockContext.Setup(m => m.Members).Returns(mock.Object);
            var s = new MemberService(mockContext.Object);

            s.Add(new Member());

            mockContext.Verify(s=>s.Add(It.IsAny<Member>()),Times.Once());
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }
    }
}
