using LibraryData.Models;
using Microsoft.AspNetCore.Razor.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Collection
{
    public class ItemSearchViewModel
    {
        public ItemSearchViewModel()
        {
            Results = Enumerable.Empty<LibraryItem>();
        }

        public string SearchTerm { get; set; }

        public IEnumerable<LibraryItem> Results { get; internal set; }
    }
}

