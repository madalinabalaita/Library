using System;

namespace Library.Data.Models
{
    public class Member
    {
        public int Id { get; set; }

        //personal data about a member + picture
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string Gender { get; set; }
        public string PhoneNr { get; set; }

        public DateTime DateOfBirth { get; set; }


        //the library subscription
        public virtual LibrarySubscription LibrarySubscription { get; set; }
       

    }
}
