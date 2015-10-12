using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Autofac;
using Owin;


namespace $safeprojectname$
{

	public class Startup
	{

		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();
			var builder = new ContainerBuilder();

			// Set working directory
			Environment.CurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

			//System.IO.File.WriteAllText(Environment.CurrentDirectory + @"\dir.txt",
			//	String.Format("{0} / {1}", Environment.CurrentDirectory,
			//	System.AppDomain.CurrentDomain.BaseDirectory));

			// Handler
			// config.MessageHandlers.Add(new SimpleCorsHandler());

			// cativate CORS
			var cors = new EnableCorsAttribute(origins: "http://localhost:9999",
				headers: "*", methods: "*") { SupportsCredentials = true };
			config.EnableCors(cors);

			// further middleware ...
			app.UseWinauth();
			app.RegisterDependencies(ref config, ref builder);

			// continue OWIN pipeline (Web API)
			app.UseWebApi(ref config);
			app.UseWelcomePage();
		}

	}

}