using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public async Task RegisterUser_ShouldReturnSuccess()
        {
            var client = new HttpClient();

            var json = """
            {
              "firstName": "Test",
              "lastName": "User",
              "email": "testuser123@gmail.com",
              "password": "Test@123"
            }
            """;

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                "https://localhost:7145/api/User/register",
                content);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}