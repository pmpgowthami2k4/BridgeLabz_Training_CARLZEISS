using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace FundooNotes.Tests
{
    [TestClass]
    public class NotesServiceTests
    {
        [TestMethod]
        public async Task GetNotes_ShouldReturnSuccess()
        {
            var client = new HttpClient();

            var response = await client.GetAsync(
                "https://localhost:7053/api/Notes");

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}