using LibraryData.Models;
using System.Collections.Generic;


namespace LibraryData
{
   public interface IMember
    {
        Member Get(int id);
        IEnumerable<Member> GetAll();
        void Add(Member newMember);
        IEnumerable<BorrowHistory> GetBorrowHistory(int memberID);
        IEnumerable<Hold> GetHolds(int memberID);
        IEnumerable<Borrow> GetBorrows(int memberID);
    }
}
