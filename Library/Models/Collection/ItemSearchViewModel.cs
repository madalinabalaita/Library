using LibraryData.Models;
using System.Collections.Generic;
using System.Linq;


namespace Library.Models.Collection
{
    public class ItemSearchViewModel
    {
        public string SearchTerm { get; set; }


        public ItemSearchViewModel()
        {
            Results = Enumerable.Empty<LibraryItem>();
        }

        

        public IEnumerable<LibraryItem> Results { get; internal set; }
    }
}

