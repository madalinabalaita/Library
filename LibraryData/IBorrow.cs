using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
   public  interface IBorrow
    {

        IEnumerable<Borrow> GetAll();
        Borrow GetById(int borrowId);
        void Add(Borrow newBorrow);
        void BorrowItem(int itemId, int librarySubscriptionId);
        void ReturnItem(int itemid, int librarySubscriptionId);
        void PlaceHold(int itemid, int librarySubscriptionId);
        string GetCurrentHoldMemberName(int id);
        DateTime GetCurrentHoldPlaced(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);
        void MarkLost(int itemId);
        void MarkFound(int itemId);

    }
}
