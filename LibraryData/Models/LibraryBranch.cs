using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public class LibraryBranch
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNr { get; set; }

        public string About { get; set; }
        public DateTime OpenDate { get; set; }

        public virtual IEnumerable<Member> Members { get; set;}
        public virtual IEnumerable<LibraryItem> LibraryItems { get; set; }

        public string ImageUrl { get; set; }
    }
}
