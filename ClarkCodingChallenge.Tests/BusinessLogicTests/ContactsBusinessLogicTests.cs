using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;

namespace ClarkCodingChallenge.Tests.BusinessLogicTests
{
    [TestClass]
    public class ContactsBusinessLogicTests
    {
        private readonly HttpClient _client;

        [TestMethod]
        public async void TestGetContactsApiRequest()
        {
            var response = await _client.GetAsync("/contacts");
            response.EnsureSuccessStatusCode();
        }
    }
}
