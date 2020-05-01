using Library.Models.Collection;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class CollectionController:Controller
    {
        private ILibraryItem _items;

        public CollectionController(ILibraryItem items)
        {
            _items = items;
        }
        public IActionResult Index()
        {
            var itemModels = _items.GetAll();
            var listingResult = itemModels
                .Select(result => new ItemIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl=result.ImageUrl,
                    AOD=_items.GetAOD(result.Id),
                    DeweyNr=_items.GetDeweyNr(result.Id),
                    Title=result.Title,
                    Type=_items.GetType(result.Id)

                });
            var model = new ItemIndexModel()
            { 
                Items =listingResult
            };
            return View(model);
        }

    }
}
