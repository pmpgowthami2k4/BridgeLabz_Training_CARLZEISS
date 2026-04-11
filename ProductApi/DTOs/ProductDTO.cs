//Your Model = full database structure

//But API should NOT expose everything.

//So we create a DTO (Data Transfer Object)

namespace ProductApi.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        //Why no Id?

//Client should NOT send Id when creating
//DB will generate it
    }
}