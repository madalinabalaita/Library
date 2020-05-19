using Library.Data.Models;
using System;
using System.Collections.Generic;

namespace Library.Data
{
   public  interface IBorrow
    {
        void Add(Borrow newBorrow);
        void BorrowItem(int itemId, int librarySubscriptionId);
        void ReturnItem(int itemId);
        void PlaceHold(int itemId, int librarySubscriptionId);
        void MarkLost(int id);
        void MarkFound(int id);
        string GetCurrentHoldMemberName(int id);
        string GetCurrentBorrowMember(int itemId);
        bool IsBorrowed(int id);
        IEnumerable<Borrow> GetAll();
        IEnumerable<BorrowHistory> GetBorrowHistory(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);
        Borrow GetById(int borrowId);
        Borrow GetLatestBorrow(int itemId);
        DateTime GetCurrentHoldPlaced(int id);



    }
}
