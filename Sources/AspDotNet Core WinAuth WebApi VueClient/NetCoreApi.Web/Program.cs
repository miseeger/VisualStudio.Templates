using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using $safeprojectname$;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace $safeprojectname$
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                
                // https://docs.microsoft.com/de-de/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.1
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(
                        Environment.CurrentDirectory 
                        + (hostingContext.HostingEnvironment.IsDevelopment()?@"\bin\Debug\$targetframework$":""));
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })

                // https://github.com/NLog/NLog.Web/wiki/Getting-started-with-ASP.NET-Core-2
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })

                .UseNLog()

                // For Hosting on IIS
                .UseIISIntegration()

                .UseStartup<Startup>();
    }
}
