using Library.Models.Collection;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class SearchController:Controller
    {
        private ILibraryItem _items;

        public SearchController(ILibraryItem items)
        {
            _items = items;
            
        }
    
        public async Task<IActionResult> IndexAsync(ItemSearchViewModel viewModel)
        {
            var results = await _items.SearchItemsAsync(viewModel.SearchTerm);

            return View(new ItemSearchViewModel
            {
                SearchTerm = viewModel.SearchTerm,
                Results = results
            });
        }
        
    }
}
