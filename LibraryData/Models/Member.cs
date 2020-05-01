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

        //public virtual LibraryCard LibraryCard{get;set;}
    }
}
