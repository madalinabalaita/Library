using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BorrowModel
{
    public class BorrowModel
    {
        public string LibrarySubscriptionId { get; set; }
        public string Title { get; set; }
        public int ItemId { get; set; }
        public string ImageUrl { get; set; }
        public int HoldCount { get; set; }
        public bool IsBorrowed { get; set; }

        public string FullName { get; set; }

    }
}
