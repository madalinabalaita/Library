using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
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
