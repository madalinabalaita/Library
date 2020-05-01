﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNr { get; set; }

        //the library branch he is subscribed at
        public virtual LibraryBranch HomeLibraryBranch { get; set; }
        //the library subscription
        public virtual LibrarySubscription LibrarySubscription { get; set; }
        public string ImageUrl { get; set; }

    }
}
