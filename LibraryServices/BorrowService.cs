using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LibraryServices
{
    public class BorrowService : IBorrow
    {
        LibraryDbContext _context;

       

        public BorrowService(LibraryDbContext context){
            _context = context;
            }
        public void Add(Borrow newBorrow)
        {
            _context.Add(newBorrow);
            _context.SaveChanges();
        }

       
        public IEnumerable<Borrow> GetAll()
        {
            return _context.Borrows;
        }

        public Borrow GetById(int borrowId)
        {
            return GetAll().FirstOrDefault(borrow => borrow.Id == borrowId);
        }

        public IEnumerable<BorrowHistory> GetBorrowHistory(int id)
        {
            return _context.BorrowHistories
                .Include(h=>h.LibraryItem)
                .Include(h=>h.LibrarySubscription)
                .Where(h => h.LibraryItem.Id == id);
        }

        public Borrow GetLatestBorrow(int itemId)
        {
            return _context.Borrows.Where(b => b.LibraryItem.Id == itemId).OrderByDescending(d => d.Since).FirstOrDefault();
        }
        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            return _context.Holds.Include(h => h.LibraryItem).Where(h => h.LibraryItem.Id== id);
        }
/*
        public void MarkFound(int itemId)
        {
            var now = DateTime.Now;
           
            UpdateItemStatus(itemId, "Available");
            RemoveExistingBorrows(itemId);
            CloseExistingBorrowHistory(itemId,now);
           
            _context.SaveChanges();
        }
*/
        private void UpdateItemStatus(int itemId, string newStatus)
        {
            var item = _context.LibraryItems
                    .FirstOrDefault(a => a.Id ==itemId);

            _context.Update(item);
            item.Status = _context.Statuses
                .FirstOrDefault(status => status.Name == newStatus);
        }

        private void CloseExistingBorrowHistory(int itemId,DateTime now)
        {
            

            //close any existing borrow history
            var history = _context.BorrowHistories.FirstOrDefault(h => h.LibraryItem.Id == itemId && h.Returned == null);

            if (history != null)
            {
                _context.Update(history);
                history.Returned = now;
            }
        }

        private void RemoveExistingBorrows( int itemId)
        {
            //remove any other borrows on the item
            var borrow = _context.Borrows.FirstOrDefault(b => b.LibraryItem.Id == itemId);
            if (borrow != null)
            {
                _context.Remove(borrow);
            }
        }

       /* public void MarkLost(int id)
        {
          
            var item = _context.LibraryItems
                   .FirstOrDefault(i => i.Id == id);
            _context.Update(item);

            item.Status = _context.Statuses.FirstOrDefault(a => a.Name == "Lost");

            _context.SaveChanges();
        }
        */
       
        public void ReturnItem(int itemId)
        {
            var now = DateTime.Now;
            var item = _context.LibraryItems
                .FirstOrDefault(a => a.Id == itemId);


            //remocve any existing checkouts on the item

            RemoveExistingBorrows(itemId);
            //close any existing checkout history
            CloseExistingBorrowHistory(itemId, now);
            //look for existing holds on the item
            var currentHolds = _context.Holds
                .Include(h => h.LibraryItem)
                .Include(h => h.LibrarySubscription)
                .Where(h => h.LibraryItem.Id ==itemId);
            //if there are holds, checkout on the item to the librarycard with the earliest hold.
            if (currentHolds.Any())
            {
               BorrowToEarliestHold(itemId, currentHolds);
                return;
            }
            //otherwise, update the item status to available
            UpdateItemStatus(itemId, "Available");

            _context.SaveChanges();

        }

        private void BorrowToEarliestHold(int itemId, IQueryable<Hold> currentHolds)
        {
            var earliestHold = currentHolds.OrderBy(holds => holds.HoldPlaced).FirstOrDefault();
            var subscription = earliestHold.LibrarySubscription;

            _context.Remove(earliestHold);
            _context.SaveChanges();
            BorrowItem(itemId, subscription.Id);
        }

        public void BorrowItem(int itemId, int librarySubscriptionId)
        {var now=DateTime.Now;
            if (IsBorrowed(itemId))
            {
                return;
            }
            var item = _context.LibraryItems.FirstOrDefault(i => i.Id == itemId);

            UpdateItemStatus(itemId, "Borrowed");
            var librarySubscription = _context.LibrarySubscriptions.Include(s => s.Borrows).FirstOrDefault(s=>s.Id== librarySubscriptionId);
            var borrow = new Borrow
            {
                LibraryItem = item,
                LibrarySubscription = librarySubscription,
                Since = now,
                Until = GetDefaultBorrowTime(now)
            };
            _context.Add(borrow);
            var borrowHistory = new BorrowHistory
            {
                Borrowed=now,
                LibraryItem=item,
                LibrarySubscription=librarySubscription
            };
            _context.Add(borrowHistory);
            _context.SaveChanges();
        }

        private DateTime GetDefaultBorrowTime(DateTime now)
        {
            return now.AddDays(30);
        }

        public bool IsBorrowed(int itemId)
        {
            var isBorrowed = _context.Borrows.Where(b => b.LibraryItem.Id == itemId).Any();
            return isBorrowed;
        }

        public void PlaceHold(int itemId, int librarySubscriptionId)
        {
            var now = DateTime.Now;

            var item = _context.LibraryItems.Include(i=>i.Status).FirstOrDefault(i => i.Id == itemId);
            var subscription = _context.LibrarySubscriptions.FirstOrDefault(s => s.Id == librarySubscriptionId);
            if(item.Status.Name == "Available")
            {
                UpdateItemStatus(itemId, "On Hold");
            }
            var hold = new Hold
            {
                HoldPlaced = now,
                LibraryItem = item,
                LibrarySubscription = subscription

            };
            _context.Add(hold);
            _context.SaveChanges();
        }

        public string GetCurrentHoldMemberName(int id)
        {
            var hold = _context.Holds.Include(h => h.LibraryItem).Include(h => h.LibrarySubscription).FirstOrDefault(h => h.Id == id);
            //if it's null also the name will be
            var subscriptionId = hold?.LibrarySubscription.Id;

            var member = _context.Members.Include(m => m.LibrarySubscription).FirstOrDefault(m => m.LibrarySubscription.Id == subscriptionId);

            return member?.FirstName + " " + member?.LastName;

        }

        public DateTime GetCurrentHoldPlaced(int id)
        {
            var hold = _context.Holds.Include(h => h.LibraryItem).Include(h => h.LibrarySubscription).FirstOrDefault(h => h.Id == id).HoldPlaced;
            return hold;

        }

        public string GetCurrentBorrowMember(int itemId)
        {
            var borrow = GetBorrowByItemId(itemId);
            if (borrow == null) {
                return " ";
            
            }
            var subscriptionId = borrow.LibrarySubscription.Id;
            var member = _context.Members.Include(m => m.LibrarySubscription).FirstOrDefault(m => m.LibrarySubscription.Id == subscriptionId);
            return member.FirstName + " " + member.LastName;
        }

        private Borrow GetBorrowByItemId(int itemId)
        {
            var borrow = _context.Borrows.Include(b => b.LibraryItem).Include(b => b.LibrarySubscription)
                 .FirstOrDefault(b => b.LibraryItem.Id == itemId);
            return borrow;
        }


        public void MarkLost(int id)
        {
            var item = _context.LibraryItems
                .First(a => a.Id == id);

            _context.Update(item);
            //we change the status to "Lost"
            item.Status = _context.Statuses.FirstOrDefault(a => a.Name == "Lost");

            _context.SaveChanges();
        }

        public void MarkFound(int id)
        {
            var item = _context.LibraryItems
                .First(a => a.Id == id);

            _context.Update(item);
            item.Status = _context.Statuses.FirstOrDefault(a => a.Name == "Available");
            var now = DateTime.Now;

            // remove any existing borrowed on the item
            var checkout = _context.Borrows
                .FirstOrDefault(a => a.LibraryItem.Id == id);
            if (checkout != null) _context.Remove(checkout);

            // close any existing borroed history
            var history = _context.BorrowHistories
                .FirstOrDefault(h =>
                    h.LibraryItem.Id == id
                    && h.Borrowed == null);
            if (history != null)
            {
                _context.Update(history);
                history.Borrowed = now;
            }

            _context.SaveChanges();
        }
    }
}
