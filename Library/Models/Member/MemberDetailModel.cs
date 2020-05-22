using Library.Data.Models;
using System;
using System.Collections.Generic;

namespace Library.Web.Models.Member
{
    public class MemberDetailModel
    {
        public int Id { get; set; }
        public int LibrarySubscriptionId { get; set; }

        public decimal OverdueFees { get; set; }


        /*
        *public string FullName{
        * get{
        * return FirstName+" "+LastName;
        * }
        * }
        */
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public string MemberSince { get; set; }
        public string DateOfBirth { get; set; }

        public IEnumerable<Borrow> ItemsBorrowed { get; set; }
        public IEnumerable<BorrowHistory> BorrowHistory { get; set; }
        public IEnumerable<Hold> Holds { get; set; }

    }
}
