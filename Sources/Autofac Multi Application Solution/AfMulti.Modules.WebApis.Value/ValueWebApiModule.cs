using System;
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using AutofacModularity;

namespace $safeprojectname$
{


	public class ValueWebApiModule : ConfigurableModule
	{

		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			var baseDir = AppDomain.CurrentDomain.BaseDirectory;

			builder.RegisterAssemblyModuleFromFile(
				@".\$ext_safeprojectname$.Modules.Common.Services.dll",
				(f) => System.Console.WriteLine("      {0}", f));
				
			builder.RegisterAssemblyModuleFromFile(
				@".\$ext_safeprojectname$.Modules.Domain.Value.dll",
				(f) => System.Console.WriteLine("      {0}", f));
				

			builder
				.RegisterApiControllers(Assembly.GetExecutingAssembly());

			builder
				.RegisterType<AuthMiddleware>().InstancePerRequest();

		}

	}

}