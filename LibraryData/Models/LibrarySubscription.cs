using System;
using System.Collections.Generic;


namespace Library.Data.Models
{
    public class LibrarySubscription
    {
        public int Id { get; set; }

        //Fees of the current member
        public decimal Fees { get; set; }

        //when it was created
        public DateTime Created { get; set; }

        //borrows under the library subscription
        public virtual IEnumerable<Borrow> Borrows{ get; set; }
    }
}
