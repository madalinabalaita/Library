using Library.Models.Collection;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class CollectionController : Controller
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
                    ImageUrl = result.ImageUrl,
                    AOD = _items.GetAOD(result.Id),
                    DeweyNr = _items.GetDeweyNr(result.Id),
                    Title = result.Title,
                    Type = _items.GetType(result.Id)

                });
            var model = new ItemIndexModel()
            {
                Items = listingResult
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var item = _items.GetById(id);
            var model = new ItemDetailModel
            {
                ItemId = id,
                Title = item.Title,
                Year = item.Year,
                Price = item.Price,
                Status = item.Status.Name,
                ImageUrl = item.ImageUrl,
                AOD = _items.GetAOD(id),
                CurrentLocation = _items.GetCurrentLocation(id).Name,
                DeweyNr = _items.GetDeweyNr(id),
                ISBN = _items.GetISBN(id),




            };
            return View(model);
        }

    }
}
