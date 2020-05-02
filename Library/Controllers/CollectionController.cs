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
        private IBorrow __borrow;

        public CollectionController(ILibraryItem items,IBorrow borrow)
        {
            _items = items;
            __borrow = borrow;
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
            var currentHolds = __borrow.GetCurrentHolds(id).Select(h => new ItemHoldModel
            {
                HoldPlaced=__borrow.GetCurrentHoldPlaced(h.Id).ToString("d"),
                MemberName=__borrow.GetCurrentHoldMemberName(h.Id)
            });
            var model = new ItemDetailModel
            {
                ItemId = id,
                Title = item.Title,
                Type = _items.GetType(id),
                Year = item.Year,
                Price = item.Price,
                Status = item.Status.Name,
                ImageUrl = item.ImageUrl,
                AOD = _items.GetAOD(id),
                CurrentLocation = _items.GetCurrentLocation(id).Name,
                DeweyNr = _items.GetDeweyNr(id),
                BorrowHistory = __borrow.GetBorrowHistory(id),
                ISBN = _items.GetISBN(id),
                LatestBorrow=__borrow.GetLatestBorrow(id),
                MemberName=__borrow.GetCurrentBorrowMember(id),
                CurrentHolds=currentHolds

            };
            return View(model);
        }

    }
}
