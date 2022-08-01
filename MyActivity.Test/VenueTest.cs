using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using MyActivity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
//using IntegrationTestTalk.;


namespace MyActivity.Test
{

    //public class VenueTest : IntegrationTest
    //{
    //    protected readonly HttpClient TestClient;
    //    protected IntegrationTest()
    //    {
    //        var appFactory = new WebApplicationFactory<Program>();
    //        TestClient = appFactory.CreateClient();
    //    }
    //    public async Task Index_Returns()
    //    {

    //    }
    //}

    //public class CustomWebApplicationFactory<TStartup>
    //: WebApplicationFactory<TStartup> where TStartup : class
    //{
    //    protected override void ConfigureWebHost(IWebHostBuilder builder)
    //    {
    //        builder.ConfigureServices(services =>
    //        {
    //            var descriptor = services.SingleOrDefault(
    //                d => d.ServiceType ==
    //                    typeof(DbContextOptions<ApplicationDbContext>));

    //            services.Remove(descriptor);

    //            services.AddDbContext<ApplicationDbContext>(options =>
    //            {
    //                options.UseSqlServer("InMemoryDbForTesting");
    //            });

    //            var sp = services.BuildServiceProvider();

    //            using (var scope = sp.CreateScope())
    //            {
    //                var scopedServices = scope.ServiceProvider;
    //                var db = scopedServices.GetRequiredService<ApplicationDbContext>();
    //                //var logger = scopedServices
    //                //    .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

    //                db.Database.EnsureCreated();


    //            }
    //        });
    //    }
    //}

    //public class VenueTest
    //{
    //    [Fact]
    //    public void Test1()
    //    {
    //        var waf = new WebApplicationFactory<Program>();
    //        var client = waf.CreateDefaultClient();
    //        var response = client.GetAsync()

    //    }
    //}
}
