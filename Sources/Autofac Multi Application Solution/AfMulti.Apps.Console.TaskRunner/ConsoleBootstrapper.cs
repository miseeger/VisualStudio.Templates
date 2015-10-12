using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using AutofacModularity;
using AutofacModularity.Interfaces;
using $ext_safeprojectname$.Common.Interfaces.Services;

namespace $safeprojectname$
{

	public class ConsoleBootstrapper : AbstractBootstrapper
	{
		public string[] Args { get; set; }

		protected override void ConfigureContainer(ContainerBuilder builder)
		{
			System.Console.Write("TaskRunner - configuring plugins ...");

			builder.RegisterAssemblyModuleFromFile(
				@".\$ext_safeprojectname$.Modules.Common.Services.dll");

			builder.RegisterAssemblyModulesFromDirectory(
				@".\", "$ext_safeprojectname$.Modules.Plugins", "~");

			System.Console.WriteLine(" done.");
		}


		protected override void PostConfigureContainer(IContainer container)
		{
			if (Args != null && Args.Length > 0)
			{
				var infoService = container.Resolve<IGlobalInfoService>();
				infoService["Args"] = Args;
			}
		}


		protected override void RegisterShell(ContainerBuilder builder)
		{
			builder.RegisterType<Shell>().As<IShell>();
		}

	}

}