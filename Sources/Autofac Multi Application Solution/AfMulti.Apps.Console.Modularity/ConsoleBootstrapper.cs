using Autofac;
using AutofacModularity;
using AutofacModularity.Interfaces;

namespace $safeprojectname$
{

	public class ConsoleBootstrapper : AbstractBootstrapper
	{

		protected override void ConfigureContainer(ContainerBuilder builder)
		{
			System.Console.WriteLine("Configuring DI Container ...");

			builder.RegisterAssemblyModuleFromFile(@".\$ext_safeprojectname$.Modules.Common.Services.dll",
				(f) => System.Console.WriteLine("   {0}",f));

			builder.RegisterAssemblyModulesFromDirectory(@".\", "$ext_safeprojectname$.Modules.Plugins", "~",
				(f) => System.Console.WriteLine("   {0}", f));
		}


		protected override void RegisterShell(ContainerBuilder builder)
		{
			builder.RegisterType<Shell>().As<IShell>();
		}

	}

}