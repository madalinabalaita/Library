﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
   public class Book:LibraryItem
    {
        //International Standard Book Number 
        [Required]
        public string ISBN { get; set;}

        [Required]
        public string Author { get; set; }

        //The Dewey Decimal System is a way to put books in order by subject.
        [Required]
        public string DeweyNr { get; set; }
    }
}
