namespace YummyRestaurant.WebApi.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; } // One Category has many Products (One-to-Many)
    }
}
