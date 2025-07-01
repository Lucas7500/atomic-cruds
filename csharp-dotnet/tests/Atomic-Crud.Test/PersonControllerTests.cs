using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Atomic_Crud.Test
{
    [TestFixture]
    public class PersonControllerTests
    {
        private HttpClient _client;

        [OneTimeSetUp]
        public void Setup()
        {
            var factory = new WebApplicationFactory<Program>();
            _client = factory.CreateClient();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _client.Dispose();
        }

        [Test]
        public async Task GetAll_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/api/v1/person");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GetAll_ReturnsMessage()
        {
            var response = await _client.GetAsync("/api/v1/person");
            var content = await response.Content.ReadAsStringAsync();

            StringAssert.Contains("Its Working", content);
        }
    }
}