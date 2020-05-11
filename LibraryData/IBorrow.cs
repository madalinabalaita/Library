using LibraryData.Models;
using System;
using System.Collections.Generic;

namespace LibraryData
{
   public  interface IBorrow
    {

        IEnumerable<Borrow> GetAll();
        Borrow GetById(int borrowId);
        void Add(Borrow newBorrow);
        void BorrowItem(int itemId, int librarySubscriptionId);
        void ReturnItem(int itemId);
        void PlaceHold(int itemId, int librarySubscriptionId);
        string GetCurrentHoldMemberName(int id);
        IEnumerable<BorrowHistory> GetBorrowHistory(int id);
        DateTime GetCurrentHoldPlaced(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);
       // void MarkLost(int itemId);
        //void MarkFound(int itemId);
        bool IsBorrowed(int id);
        Borrow GetLatestBorrow(int itemId);
        string GetCurrentBorrowMember(int itemId);
        void MarkLost(int id);
        void MarkFound(int id);

    }
}
