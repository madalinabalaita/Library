using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Member
{
    public class MemberDetailModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        /*
         *public string FullName{
         * get{
         * return FirstName+" "+LastName;
         * }
         * }
         */
         public string Gender { get; set; }
        public int LibrarySubscriptionId { get; set; }
        public DateTime MemberSince { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public decimal OverdueFees { get; set; }

        public IEnumerable<Borrow> ItemsBorrowed { get; set; }
        public IEnumerable<BorrowHistory> BorrowHistory { get; set; }
        public IEnumerable<Hold> Holds { get; set; }

    }
}
