using System;
using System.ComponentModel.DataAnnotations;


namespace Library.Data.Models
{
    public class Borrow
    {
        public int Id { get; set; }

        //book/movie/magazine
        [Required]
        public LibraryItem LibraryItem { get; set; }
        //the library subscription of a member
        public LibrarySubscription LibrarySubscription { get; set; }

        //date times for when an item was borrowed (Since) and when it's due time (Until)
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }
    }
}
