using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;
using $ext_safeprojectname$.Core.Data;

namespace $safeprojectname$
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            // ----------------------------------------------------------------
            // Only needed when initially seeding the DB 
            // ----------------------------------------------------------------
            //var host = CreateWebHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var dbContext = services.GetRequiredService<DataContext>();

            //    // dbContext.Database.Migrate();
            //    dbContext.EnsureSeeded();
            //}

            //host.Run();
            // ----------------------------------------------------------------
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)

                // https://docs.microsoft.com/de-de/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.1
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(
                        Environment.CurrentDirectory
                        + (hostingContext.HostingEnvironment.IsDevelopment() ? @"\bin\Debug\$targetframework$" : ""));
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
