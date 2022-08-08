//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.Extensions.Options;
//using System.Net;
//using System.Net.Http.Headers;
//using System.Security.Claims;
//using System.Text.Encodings.Web;

//namespace TestProject2
//{
//    public class TestAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//    {
//        public TestAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
//            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
//            : base(options, logger, encoder, clock)
//        {
//        }

//        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
//        {
//            var claims = new[] { new Claim(ClaimTypes.Name, "Test user") };
//            var identity = new ClaimsIdentity(claims, "Test");
//            var principal = new ClaimsPrincipal(identity);
//            var ticket = new AuthenticationTicket(principal, "Test");

//            var result = AuthenticateResult.Success(ticket);

//            return Task.FromResult(result);
//        }
//        [Fact]
//        public async Task Get_SecurePageIsReturnedForAnAuthenticatedUser()
//        {
//            // Arrange
//            var client = _factory.WithWebHostBuilder(builder =>
//            {
//                builder.ConfigureTestServices(services =>
//                {
//                    services.AddAuthentication("Test")
//                        .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
//                            "Test", options => { });
//                });
//            })
//                .CreateClient(new WebApplicationFactoryClientOptions
//                {
//                    AllowAutoRedirect = false,
//                });

//            client.DefaultRequestHeaders.Authorization =
//                new AuthenticationHeaderValue("Test");

//            //Act
//            var response = await client.GetAsync("/SecurePage");

//            // Assert
//            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
//        }
//    }
//}
