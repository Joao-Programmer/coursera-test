using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Restaurant.API.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.API
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    //DbInitializer.Initialize(context);
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        // public static void Main(string[] args){
        //     var host = BuildWebHost(args);

        //     using(var scope = host.Services.CreateScope())
        //     using(var context = scope.ServiceProvider.GetService<AppDbContext>()){
        //         context.Database.Migrate();
        //     }

        //     host.Run();
        // }

        // public static IWebHost BuildWebHost(string[] args) =>
        //     WebHost.CreateDefaultBuilder(args)
        //     .UseStartup<Startup>()
        //     .Build();




        // public static void Main(string[] args)
        // {
        //     CreateHostBuilder(args).Build().Run();
        // }

        // public static IHostBuilder CreateHostBuilder(string[] args) =>
        //     Host.CreateDefaultBuilder(args)
        //         .ConfigureWebHostDefaults(webBuilder =>
        //         {
        //             webBuilder.UseStartup<Startup>();
        //         });
    }
}
