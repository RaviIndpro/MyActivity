﻿//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using MyActivity.Data;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace MyActivity.Test
//{
//    public class CustomWebApplicationFactory<TStartup>
//       : WebApplicationFactory<TStartup> where TStartup : class
//    {
//        protected override void ConfigureWebHost(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices(services =>
//            {
//                var descriptor = services.SingleOrDefault(
//                    d => d.ServiceType ==
//                        typeof(DbContextOptions<ApplicationDbContext>));

//                services.Remove(descriptor);

//                //services.AddDbContext<ApplicationDbContext>(options =>
//                //{
//                //    options.UseSqlServer("ConnectionStrings");
//                //});                
//                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
//                     Configuration.GetConnectionString("DefaultConnection")
//                ));

//                var sp = services.BuildServiceProvider();

//                using (var scope = sp.CreateScope())
//                {
//                    var scopedServices = scope.ServiceProvider;
//                    var db = scopedServices.GetRequiredService<ApplicationDbContext>();
//                    var logger = scopedServices
//                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

//                    db.Database.EnsureCreated();

                   
//                }
//            });
//        }

//    }
//}
