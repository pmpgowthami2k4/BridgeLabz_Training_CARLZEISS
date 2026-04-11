using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using ProductApi.Models;
using Microsoft.Extensions.Configuration;

namespace ProductApi.Repositories
{
    public class ProductRepository
    {
        private readonly IConfiguration _config; //We need this to get the connection string from appsettings.json
        //wt is _config? it's a field that holds the configuration object, which we can use to access settings like the database connection string. 

        public ProductRepository(IConfiguration config) //we inject the configuration into the repository so we can use it to create database connections.
        {
            _config = config; //we assign the injected configuration to our private field so we can use it in our methods to create database connections.
        }

        private IDbConnection CreateConnection() //This method creates and returns a new database connection using the connection string from the configuration. We use this method whenever we need to interact with the database.
        {
            return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }

        public void AddProduct(Product product)
        {
            var query = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";

            using (var connection = CreateConnection())
            {
                connection.Execute(query, product);
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var query = "SELECT * FROM Products";

            using (var connection = CreateConnection())
            {
                return connection.Query<Product>(query);
            }
        }

        
        public void UpdateProduct(Product product) //function tp update an existing product in the database. It takes a Product object as a parameter, constructs an SQL UPDATE query, and executes it using Dapper
        {
            var query = "UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id";

            using (var connection = CreateConnection()) //We create a new database connection using the CreateConnection method. The using statement ensures that the connection is properly disposed of after we're done with it, even if an exception occurs.
            {
                connection.Execute(query, product); 
            }
        } 

        public void DeleteProduct(int id) 
        {
            var query = "DELETE FROM Products WHERE Id = @Id";

            using (var connection = CreateConnection())
            {
                connection.Execute(query, new { Id = id });
            }
        }

      

    }
}
