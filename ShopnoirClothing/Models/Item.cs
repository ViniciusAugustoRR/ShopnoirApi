using System.Data.SqlTypes;

namespace ShopnoirClothing.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }

}
