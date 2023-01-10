namespace Models.Data
{
    public class Tours
    {
        public List<Tour>? tours { get; set; }
    }
    public class Tour
    {
        public int id { get; set; }
        public string? title { get; set; }
        public int price { get; set; }
        public string? currency { get; set; }
        public double rating { get; set; }
        public bool isSpecialOffer { get; set; }
    }
}