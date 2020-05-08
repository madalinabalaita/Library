using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryServices
{
   public class MemberService : IMember
    {
        private LibraryDbContext _context;
        public MemberService(LibraryDbContext context)
        {
            _context = context;
        }
        public void Add(Member newMember)
        {
            _context.Add(newMember);
            _context.SaveChanges();
        }

        public Member Get(int id)
        {
            return _context.Members.Include(m => m.LibrarySubscription).FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Member> GetAll()
        {
            return _context.Members.Include(m => m.LibrarySubscription);
        }

        public IEnumerable<BorrowHistory> GetBorrowHistory(int memberID)
        {//we get the member and from that we get the subscription and then its ID
            var subscriptionID = _context.Members.Include(m => m.LibrarySubscription).FirstOrDefault(m => m.Id == memberID).LibrarySubscription.Id;
            return _context.BorrowHistories.Include(b => b.LibrarySubscription).Include(b => b.LibraryItem).Where(b => b.LibrarySubscription.Id == subscriptionID).OrderByDescending(b => b.Borrowed);
        }

        public IEnumerable<Borrow> GetBorrows(int memberID)
        {//Get(memberId).LibrarySubscription.Id
            var subscriptionID = _context.Members.Include(m => m.LibrarySubscription).FirstOrDefault(m => m.Id == memberID).LibrarySubscription.Id;
            return _context.Borrows.Include(b => b.LibrarySubscription).Include(b => b.LibraryItem).Where(b => b.LibrarySubscription.Id == subscriptionID);
        }

        public IEnumerable<Hold> GetHolds(int memberID)
        {
            var subscriptionID = _context.Members.Include(m => m.LibrarySubscription).FirstOrDefault(m => m.Id == memberID).LibrarySubscription.Id;
            return _context.Holds.Include(h => h.LibrarySubscription).Include(h => h.LibraryItem).Where(h => h.LibrarySubscription.Id == subscriptionID).OrderByDescending(h => h.HoldPlaced);
        }
    }
}
