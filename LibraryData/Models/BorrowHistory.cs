using System;
using System.ComponentModel.DataAnnotations;


namespace Library.Data.Models
{
   public class BorrowHistory
    {
        public int Id { get; set; }

        //what item had been borrowed
        [Required]
        public LibraryItem LibraryItem { get; set; }

        //by whom it was borrowed
        [Required]
        public LibrarySubscription LibrarySubscription { get; set; }

        //time of borrow
        [Required]
        public DateTime Borrowed { get; set; }

        //time of return if it is returned, ?- nullable
        public DateTime? Returned { get; set; }
    }
}
