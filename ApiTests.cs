using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using NUnit.Framework;
using RestSharp;
using ShortUrlApiTests;

namespace ShortUrl_APITests
{
    public class APITests

    {
        private RestClient client;
        private RestRequest request;
        private const string baseUrl = "https://shorturl.nakov.repl.co/api/urls";

        [SetUp]
        public void Setup()
        {
            client = new RestClient(baseUrl);
        }


        [Test]
        public void Test_ListUrlByShortCode_ValidData()
        {
            // Arrange
            request = new RestRequest(baseUrl);

            // Act
            var response = client.Execute(request);
            var shorturls = JsonSerializer.Deserialize<List<ShortUrl>>(response.Content);

            // Assert
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.That(shorturls[0].shortCode, Is.EqualTo("nak"));


        }

        [Test]
        public void Test_ListShortUrls()
        {
            // Arrange
            request = new RestRequest(baseUrl);

            // Act
            var response = client.Execute(request);
            var shorturls = JsonSerializer.Deserialize<List<ShortUrl>>(response.Content);

            // Assert
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.NotNull(shorturls);


        }

        [Test]
        public void Test_CreateSHortUrl_ValidData()
        {
            // Arrange
            request = new RestRequest(baseUrl);
            var body = new
            {

                url = "https://AYEBRAT.com",
                shortCode = "AYEBRAT",
                shortUrl = "http://shorturl.nakov.repl.co/go/AYEBRAT"


            };
            request.AddJsonBody(body);

            var response = this.client.Execute(request, Method.Post);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.NotNull(response.Content);

        }

        [Test]
        public void Test_DeleteSHortUrl()
        {
            // Arrange
            request = new RestRequest("https://shorturl.nakov.repl.co/api/urls/nakdgee");
            var body = new
            {

                url = "https://nakdgee.com",
                shortCode = "nakdgee",
                shortUrl = "http://shorturl.nakov.repl.co/go/nakdgee"


            };
            request.AddJsonBody(body);

            var response = this.client.Execute(request, Method.Delete);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.NotNull(response.Content);

        }
    }

}
