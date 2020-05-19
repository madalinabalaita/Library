namespace Library.Web.Models.BorrowModel
{
    public class BorrowModel
    {
        public int ItemId { get; set; }
        public int HoldCount { get; set; }

        public bool IsBorrowed { get; set; }

        public string LibrarySubscriptionId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

    }
}
