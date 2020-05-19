using System;


namespace Library.Data.Models
{
    public class Hold
    {
        public int Id { get; set; }

        //item to hold, virtual-when you want to load a collection form the database the first time it is accesed
        public virtual LibraryItem LibraryItem { get; set; }

        //meber who wants to hold an item
        public virtual LibrarySubscription LibrarySubscription { get; set; }


        //when the hold was placed-queue of holds
        public DateTime HoldPlaced { get; set; }
    }
}
