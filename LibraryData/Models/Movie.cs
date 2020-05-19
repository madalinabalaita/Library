using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Movie:LibraryItem
    {
        [Required]
        public string Director { get; set; }
    }
}
