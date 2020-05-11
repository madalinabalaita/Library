using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Movie:LibraryItem
    {
        [Required]
        public string Director { get; set; }
    }
}
