namespace Library.Models.Collection
{
    public class ItemIndexListingModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string AOD { get; set; }//author or director
        public string Type { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }
        public string DeweyNr { get; set; }
        public string NrCopies { get; set; }

    }
}
