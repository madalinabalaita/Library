using Microsoft.EntityFrameworkCore;
using System;
using LibraryData.Models;

namespace LibraryData
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options) { }
         public DbSet<Member> Members { get; set; }
    }
}
