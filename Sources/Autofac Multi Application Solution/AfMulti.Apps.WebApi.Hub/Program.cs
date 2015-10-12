using System;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;

namespace $safeprojectname$
{
	class Program
	{
		
		static void Main(string[] args)
		{
			if (System.Environment.UserInteractive)
			{
				var parameter = string.Concat(args);
				switch (parameter)
				{
					case "--install":
						ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
						Console.WriteLine("WebApi Hub was successfully installed.");
						Console.WriteLine("Please press any key ...");
						Console.ReadKey();
						break;
					case "--uninstall":
						ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
						Console.WriteLine("WebApi Hub was successfully uninstalled.");
						Console.WriteLine("Please press any key ...");
						Console.ReadKey();
						break;
				}
			}
			else
			{
				ServiceBase.Run(new ServiceBase[] { new WebApiHubService() });
			}
		}

	}

}
