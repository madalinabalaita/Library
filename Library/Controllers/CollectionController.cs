﻿using Library.Models.BorrowModel;
using Library.Models.Collection;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                    Type = _items.GetType(result.Id),
                     Genre = _items.GetGenre(result.Id)

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
                DeweyNr = _items.GetDeweyNr(id),
                BorrowHistory = __borrow.GetBorrowHistory(id),
                ISBN = _items.GetISBN(id),
                LatestBorrow=__borrow.GetLatestBorrow(id),
                MemberName=__borrow.GetCurrentBorrowMember(id),
                CurrentHolds=currentHolds,
                Genre=_items.GetGenre(id)
                

            };
            return View(model);
            
        }
        public IActionResult Borrow(int id)
        {
            var item = _items.GetById(id);
            var model = new BorrowModel
            {
                ItemId = id,
                ImageUrl = item.ImageUrl,
                Title = item.Title,
                LibrarySubscriptionId = "",
                IsBorrowed = __borrow.IsBorrowed(id)
            };
            return View(model);
        }
        public IActionResult ReturnItem(int id)
        {
            __borrow.ReturnItem(id);
            return RedirectToAction("Detail", new { id = id });
        }
        public IActionResult Hold(int id)
        {
            var item = _items.GetById(id);
            var model = new BorrowModel
            {
                ItemId = id,
                ImageUrl = item.ImageUrl,
                Title = item.Title,
                LibrarySubscriptionId = "",
                IsBorrowed = __borrow.IsBorrowed(id),
                HoldCount = __borrow.GetCurrentHolds(id).Count()
            };
            return View(model);
        }

        public IActionResult MarkLost(int itemId)
        {
            __borrow.MarkLost(itemId);
            return RedirectToAction("Detail", new { id = itemId });

        }
        public IActionResult MarkFound(int itemId)
        {
            __borrow.MarkFound(itemId);
            return RedirectToAction("Detail", new { id = itemId });

        }
        [HttpPost]
        public IActionResult PlaceBorrow(int itemId,int librarysubscriptionId)
        {
            __borrow.BorrowItem(itemId, librarysubscriptionId);
            return RedirectToAction("Detail", new { id = itemId });
        }
        [HttpPost]
        public IActionResult PlaceHold(int itemId, int librarysubscriptionId)
        {
            __borrow.PlaceHold(itemId, librarysubscriptionId);
            return RedirectToAction("Detail", new { id = itemId });
        }
    }
}
