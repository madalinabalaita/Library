using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public class Status
    {
        public int Id { get; set; }

        //name of the item
        [Required]
        public string Name { get; set; }

        //about the item
        [Required]
        public string About { get; set; }
    }
}
