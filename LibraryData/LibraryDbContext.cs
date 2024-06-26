﻿using Microsoft.EntityFrameworkCore;
using Library.Data.Models;

namespace Library.Data
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<BorrowHistory> BorrowHistories { get; set; }
      
        public DbSet<LibrarySubscription> LibrarySubscriptions { get; set; }
        public DbSet<Member> Members { get; set; }
    
        public DbSet<Status> Statuses { get; set; }
        public DbSet<LibraryItem> LibraryItems { get; set; }
        public DbSet<Hold> Holds { get; set; }
    }
}
