using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Collection
{
    public class ItemIndexListingModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        //author or director
        public string AOD { get; set; }
         public string Type { get; set; }

        public string DeweyNr { get; set; }
        public string NrCopies { get; set; }

    }
}
