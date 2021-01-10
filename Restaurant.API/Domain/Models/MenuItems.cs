namespace Restaurant.API.Domain.Models
{
    public class MenuItems
    {
        public int id { get; set; }
        public string description { get; set; }
        public string large_portion_name { get; set; }
        public string name { get; set; }
        public decimal price_large { get; set; }
        public decimal price_small { get; set; }
        public string short_name { get; set; }
        public string small_portion_name { get; set; }

        public int categoryId { get; set; }
        public Category category { get; set; }
    }
}