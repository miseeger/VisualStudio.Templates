using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.AspNetCore.Server.HttpSys;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace $safeprojectname$
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);

            var isService = !(Debugger.IsAttached || args.Contains("--console"));

            var host = WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(pathToContentRoot)
                .UseStartup<Startup>()
                .UseHttpSys(options =>
                {
                    options.Authentication.Schemes = AuthenticationSchemes.Negotiate | AuthenticationSchemes.NTLM;
                    options.Authentication.AllowAnonymous = false;
                    options.UrlPrefixes.Add("http://localhost:5000");
                })
               .Build();

            if (isService)
            {
                host.RunAsService();
            }
            else
            {
                host.Run();
            }
        }

    }

}
