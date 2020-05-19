using Library.Data.Models;
using System.Collections.Generic;

namespace Library.Web.Models.Collection
{
    public class ItemDetailModel
    {
        public int ItemId { get; set; }
        public int Year { get; set; }


        public string Title { get; set; }
        public string AOD { get; set; }
        public string Type { get; set; }
        public string ISBN { get; set; }
        public string DeweyNr { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string MemberName { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }


        public Borrow LatestBorrow { get; set; }


        public IEnumerable<BorrowHistory> BorrowHistory { get; set; }
        public IEnumerable<ItemHoldModel> CurrentHolds { get; set; }

    }
}
