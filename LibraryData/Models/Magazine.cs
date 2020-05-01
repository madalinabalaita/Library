using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public class Magazine:LibraryItem
    {
        [Required]
        public string Editor { get; set; }
    }
}
