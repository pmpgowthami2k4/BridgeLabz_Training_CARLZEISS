using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Tests
{
    [TestClass]
    public class CollaboratorServiceTests
    {
        [TestMethod]
        public async Task AddCollaborator_ShouldReturnSuccess()
        {
            var client = new HttpClient();

            var json = """
            {
              "noteId": 1,
              "collaboratorEmail": "gowthamicoco@gmail.com"
            }
            """;

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                "https://localhost:7274/api/Collaborator/add",
                content);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}