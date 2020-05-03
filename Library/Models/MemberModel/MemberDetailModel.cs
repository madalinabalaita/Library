using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.MemberModel
{
    public class MemberDetailModel
    {
        public int Id { get; set; }
        public int FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public int LibrarySubscription { get; set; }
        public DateTime MemberSince { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public decimal OverdueFees { get; set; }

        public IEnumerable<Borrow> ItemsBorrowed { get; set; }
        public IEnumerable<BorrowHistory> BorrowHistory { get; set; }
        public IEnumerable<Hold> Holds { get; set; }

    }
}
