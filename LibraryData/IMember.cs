using LibraryData.Models;
using System.Collections.Generic;


namespace LibraryData
{
   public interface IMember
    {
        void Add(Member newMember);
        Member Get(int id);
        IEnumerable<Member> GetAll();
        IEnumerable<BorrowHistory> GetBorrowHistory(int memberID);
        IEnumerable<Hold> GetHolds(int memberID);
        IEnumerable<Borrow> GetBorrows(int memberID);
    }
}
