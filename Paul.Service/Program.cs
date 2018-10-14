using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using System;
using System.IO;
using System.Reflection;

namespace Paul.Service
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                      .ReadFrom.Configuration(config)
                      .MinimumLevel.Debug()
                      .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                      .Enrich.WithProperty("App", Assembly.GetEntryAssembly().GetName().Name)
                      .Enrich.FromLogContext()
                      .WriteTo.Console()
                      .CreateLogger();
            
            try
            {
                Log.Information("Started");
                CreateWebHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
