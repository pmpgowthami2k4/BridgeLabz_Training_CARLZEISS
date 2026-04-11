//it defines the structure of data your API will send/receive.

namespace ProductApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}