using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using MyActivity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Helpers;

namespace TestProject2
{
    public class IndexPageTests :
    IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program>
            _factory;

        public IndexPageTests(
            CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }
        [Fact]
        public async Task Post_DeleteAllMessagesHandler_ReturnsRedirectToRoot()
        {
            // Arrange
            var defaultPage = await _client.GetAsync("/API/Venues");
            //var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

            //Act
            //var response = await _client.SendAsync(
               // (IHtmlFormElement)content.QuerySelector("form[id='messages']"),
                //(IHtmlButtonElement)content.QuerySelector("button[id='deleteAllBtn']"));

            // Assert
            Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
            //Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            //Assert.Equal("/", response.Headers.Location.OriginalString);
        }
        [Fact]
        public async Task Post_DeleteMessageHandler_ReturnsRedirectToRoot()
        {
            // Arrange
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var serviceProvider = services.BuildServiceProvider();

                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices
                            .GetRequiredService<ApplicationDbContext>();
                        var logger = scopedServices
                            .GetRequiredService<ILogger<IndexPageTests>>();

                        //try
                        //{
                        //    Utilities.ReinitializeDbForTests(db);
                        //}
                        //catch (Exception ex)
                        //{
                        //    logger.LogError(ex, "An error occurred seeding " +
                        //        "the database with test messages. Error: {Message}",
                        //        ex.Message);
                        //}
                    }
                });
            })
                .CreateClient(new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });
            var defaultPage = await client.GetAsync("/API/Employees");
            //var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

            //Act
            //var response = await client.SendAsync(
            //    (IHtmlFormElement)content.QuerySelector("form[id='messages']"),
            //    (IHtmlButtonElement)content.QuerySelector("form[id='messages']")
            //        .QuerySelector("div[class='panel-body']")
            //        .QuerySelector("button"));

            // Assert
            Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
            //Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            //Assert.Equal("/", response.Headers.Location.OriginalString);
        }
        
    }
}
