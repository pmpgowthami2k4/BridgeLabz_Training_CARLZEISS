using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Services
{
    public class ProductService // Service layer to handle business logic related to products
    {
        private readonly ProductRepository _repo;

        public ProductService(ProductRepository repo) //we create it because we want to use the repository to access data, but we don't want the controller to know about the repository directly. This keeps our code organized and allows us to change the data access logic without affecting the controllers.
        {
            _repo = repo;
        }

        public Product CreateProduct(Product product) //product comes from the controller, we pass it to the service, and then the service will use the repository to save it to the database. This way, the controller doesn't need to know how the data is stored or accessed, it just calls the service to do its job.


         //the controller need not know because the service abstracts away the details of how the product is created and stored
        {
            _repo.AddProduct(product);
            return product;
            //we sve the product to the repository and return it. 
        }




        public IEnumerable<Product> GetProducts()
        {
            return _repo.GetAllProducts(); //returns a list of all products from the repository.
        }



        public Product UpdateProduct(Product product)
        {
            _repo.UpdateProduct(product); 
            return product;
        }

        public void DeleteProduct(int id)
        {
            _repo.DeleteProduct(id);
        }
    }
}