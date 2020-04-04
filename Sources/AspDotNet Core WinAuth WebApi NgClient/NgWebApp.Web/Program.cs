using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace $safeprojectname$
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(
                        Environment.CurrentDirectory
                        + (hostingContext.HostingEnvironment.IsDevelopment()
                            ? @"\bin\Debug\netcoreapp3.1" : ""));
                    config.AddJsonFile("appsettings.json", optional: false,
                        reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json",
                        optional: false, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })

                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseNLog();
                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                });
    }
}

