using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using Serilog;

namespace TomeKop
{
    public class Program
    {
        public static string ConStr = "Host=localhost;Username=postgres;Password=2121;Database=tomekop";
        public static void Main(string[] args)
        {
            // http://zetcode.com/csharp/postgresql/
            
            ///subscriptions/8e63cebe-39c8-46d3-af71-498785212248/resourceGroups/First/providers/Microsoft.Resources/deployments/Microsoft.PostgreSQLServer.createPostgreSqlServer_4c09d8f933e043/operations/7AE9B2AED706BC07

            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Information()
           .WriteTo.Console()
           .WriteTo.BrowserConsole()
           .WriteTo.File("Logs/log.txt",
               rollingInterval: RollingInterval.Day,
               rollOnFileSizeLimit: true)
           .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
