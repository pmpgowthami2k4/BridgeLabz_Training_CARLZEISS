using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Tests
{
    [TestClass]
    public class LabelServiceTests
    {
        [TestMethod]
        public async Task CreateLabel_ShouldReturnSuccess()
        {
            var client = new HttpClient();

            var json = """
            {
              "userId": "1",
              "name": "MSTestLabel"
            }
            """;

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                "https://localhost:7243/api/Label/create",
                content);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
