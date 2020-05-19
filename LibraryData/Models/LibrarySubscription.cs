using System;
using System.Collections.Generic;


namespace Library.Data.Models
{
    public class LibrarySubscription
    {
        public int Id { get; set; }
        public decimal Fees { get; set; }

        public DateTime Created { get; set; }

        public virtual IEnumerable<Borrow> Borrows{ get; set; }
    }
}
