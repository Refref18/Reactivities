using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           var host= CreateHostBuilder(args).Build();
           using var scope=host.Services.CreateScope();
           //using: after we use it it is going to dispose the scope and it will not hanging there anymore 
           //scope will host any services that we create btw these {}
           var services=scope.ServiceProvider;
           try{
               //IF WE DONT HAVE THE DATABASE:
               var context=services.GetRequiredService<DataContext>();
               //we added the datacontext as service in startup
               await context.Database.MigrateAsync();
               await Seed.SeedData(context);

           }catch(Exception ex){
               var logger= services.GetRequiredService<ILogger<Program>>();
               logger.LogError(ex,"An error occurred during migration");

           }
           await host.RunAsync();//starts the application 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
