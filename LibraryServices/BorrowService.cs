using LibraryData;
using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryServices
{
    public class BorrowService : IBorrow
    {
        public void Add(Borrow newBorrow)
        {
            throw new NotImplementedException();
        }

        public void BorrowItem(int itemId, int librarySubscriptionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Borrow> GetAll()
        {
            throw new NotImplementedException();
        }

        public Borrow GetById(int borrowId)
        {
            throw new NotImplementedException();
        }

        public string GetCurrentHoldMemberName(int id)
        {
            throw new NotImplementedException();
        }

        public DateTime GetCurrentHoldPlaced(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            throw new NotImplementedException();
        }

        public void MarkFound(int itemId)
        {
            throw new NotImplementedException();
        }

        public void MarkLost(int itemId)
        {
            throw new NotImplementedException();
        }

        public void PlaceHold(int itemid, int librarySubscriptionId)
        {
            throw new NotImplementedException();
        }

        public void ReturnItem(int itemid, int librarySubscriptionId)
        {
            throw new NotImplementedException();
        }
    }
}
