
using System.ComponentModel.DataAnnotations;


namespace LibraryData.Models
{
    public abstract class LibraryItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int NrOfCopies { get; set; }
      
        public string Genre { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }
}
