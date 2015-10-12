using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Autofac;
using Autofac.Integration.WebApi;
using AutofacModularity;
using Owin;

namespace $safeprojectname$
{

	/// <summary>
	/// Bootstraps the DI-Container and loads the necessary modules for the the API into 
	/// the DI-Container. Also middleware will be loaded, here.
	/// </summary>
	public static class DependencyConfig
	{

		public static void Register(ref IAppBuilder app, ref HttpConfiguration config, ref ContainerBuilder builder)
		{

			// Register modules
			builder.RegisterAssemblyModuleFromFile(@".\$ext_safeprojectname$.Modules.Common.Services.dll",
				(f) => System.Console.WriteLine("   {0}", f));

			Console.WriteLine("\r\nLoading WebApis from Directory ...");
			builder.RegisterAssemblyModulesFromDirectory(@".\", "$ext_safeprojectname$.Modules.WebApis", "~",
				(f) => System.Console.WriteLine("   {0}", f));


			// Register Web API controller in executing assembly.
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


			// Autofac will add middleware to IAppBuilder in the order registered.
			// The middleware will execute in the order added to IAppBuilder.
			
			// !!! This is an example implementation of a small RequestLogger.
			// !!! A middleware that cares about pre-authentication
			// builder.RegisterType<RequestLogger>().InstancePerReq/uest();
			
			var container = builder.Build();
			
			// Create and assign a dependency resolver for Web API to use.
			config.DependencyResolver = 
				(IDependencyResolver) new AutofacWebApiDependencyResolver(container);
			
			// This should be the first middleware added to the IAppBuilder.
			app.UseAutofacMiddleware(container);
			
			// Make sure the Autofac lifetime scope is passed to Web API.
			app.UseAutofacWebApi(config);
			
		}

	}

}