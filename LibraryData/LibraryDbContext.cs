using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryData
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options) { }
         public DbSet<Member> Members { get; set; }
    }
}
