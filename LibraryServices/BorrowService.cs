using Library.Data;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Library.Core.Services
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
        {   //get borrow history by id (where we know the item and the subscription)
            return _context.BorrowHistories.Include(h => h.LibraryItem)
                .Include(h => h.LibrarySubscription)
                .Where(h => h.LibraryItem.Id == id);
        }

        public Borrow GetLatestBorrow(int itemId)
        { //we order the borrows  to get the latest one
            return _context.Borrows.Where(b => b.LibraryItem.Id == itemId)
                .OrderByDescending(d => d.Since)
                .FirstOrDefault();
        }
        public IEnumerable<Hold> GetCurrentHolds(int id)
        {   //we get the current holds
            return _context.Holds.Include(h => h.LibraryItem)
                .Where(h => h.LibraryItem.Id == id);
        }

        //update the status of an item
        private void UpdateItemStatus(int itemId, string newStatus)
        {   //first we get the id of the item
            var item = _context.LibraryItems
                    .FirstOrDefault(a => a.Id ==itemId);
            //we update the item
            _context.Update(item);
            //we change the status Name in the newStatus
            item.Status = _context.Statuses
                .FirstOrDefault(status => status.Name == newStatus);
        }

        private void CloseExistingBorrowHistory(int itemId,DateTime now)
        {    //close any existing borrow history

            //the item which has beend borrowed but not yet returned
            var history = _context.BorrowHistories.FirstOrDefault(h => h.LibraryItem.Id == itemId && h.Returned == null);
            //if returned, update and the time of the return is now
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

        public void ReturnItem(int itemId)
        {
            var now = DateTime.Now;
            var item = _context.LibraryItems
                .FirstOrDefault(a => a.Id == itemId);
            //remove any existing borrows on the item
            RemoveExistingBorrows(itemId);
            //close any existing borrow history
            CloseExistingBorrowHistory(itemId, now);
            //look for existing holds on the item
            var currentHolds = _context.Holds
                .Include(h => h.LibraryItem)
                .Include(h => h.LibrarySubscription)
                .Where(h => h.LibraryItem.Id ==itemId);
            //if there are holds, borrow  the item to the librarycard with the earliest hold.
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
            //we update the item to borrowed
            UpdateItemStatus(itemId, "Borrowed");
            var librarySubscription = _context.LibrarySubscriptions.Include(s => s.Borrows).FirstOrDefault(s=>s.Id== librarySubscriptionId);
            //we create a Borrow  with the Library Item borrowed, Subscription, Date of borrow and the Due Date
            var borrow = new Borrow
            {
                LibraryItem = item,
                LibrarySubscription = librarySubscription,
                Since = now,
                Until = GetDefaultBorrowTime(now)
            };
            //we add it to Borrows
            _context.Add(borrow);
            //we ceate a Borrow History with the time at which it has been borrowed, the Library Item adn the Library Subcription
            var borrowHistory = new BorrowHistory
            {
                Borrowed=now,
                LibraryItem=item,
                LibrarySubscription=librarySubscription
            };
            //we add it to BorrowHistory
            _context.Add(borrowHistory);
            //we save the changes
            _context.SaveChanges();
        }

        private DateTime GetDefaultBorrowTime(DateTime now)
        {   //the due date/time in which a library item has to be returned
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
            //we check the status of the item
            if(item.Status.Name == "Available")
            {//if it;s available but the item has been put on hold we change the status to "On Hold"
                UpdateItemStatus(itemId, "On Hold");
            }
            //we create a Hold with the time at which the Hold has been placed, the Item and the Subscription
            var hold = new Hold
            {
                HoldPlaced = now,
                LibraryItem = item,
                LibrarySubscription = subscription

            };
            //and then add it to Holds
            _context.Add(hold);
            _context.SaveChanges();
        }

        public string GetCurrentHoldMemberName(int id)
        {
            var hold = _context.Holds.Include(h => h.LibraryItem).Include(h => h.LibrarySubscription).FirstOrDefault(h => h.Id == id);
            //if it's null also the name will be
            var subscriptionId = hold?.LibrarySubscription.Id;

            var member = _context.Members.Include(m => m.LibrarySubscription).FirstOrDefault(m => m.LibrarySubscription.Id == subscriptionId);
            //if it is not null we retorn the first name and the last name
            return member?.FirstName + " " + member?.LastName;

        }

        public DateTime GetCurrentHoldPlaced(int id)
        {
            var hold = _context.Holds.Include(h => h.LibraryItem)
                .Include(h => h.LibrarySubscription)
                .FirstOrDefault(h => h.Id == id)
                .HoldPlaced;
            return hold;

        }

        public string GetCurrentBorrowMember(int itemId)
        {
            var borrow = GetBorrowByItemId(itemId);
            if (borrow == null) {
                return " ";
            
            }
            var subscriptionId = borrow.LibrarySubscription.Id;
            var member = _context.Members.Include(m => m.LibrarySubscription)
                .FirstOrDefault(m => m.LibrarySubscription.Id == subscriptionId);
            return member.FirstName + " " + member.LastName;
        }

        private Borrow GetBorrowByItemId(int itemId)
        {
            var borrow = _context.Borrows.Include(b => b.LibraryItem)
                 .Include(b => b.LibrarySubscription)
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
