using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Status
    {
        public int Id { get; set; }

        //name of the status
        [Required]
        public string Name { get; set; }

        //about the item :short description for Available/Borrowed/On hold/Lost
        [Required]
        public string About { get; set; }
    }
}
