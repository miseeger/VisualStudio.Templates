using System.Web.Http;
using Autofac;
using Owin;

namespace $safeprojectname$
{

	/// <summary>
	/// Extensions zum vereinfachten Aufruf der Middleware-Komponenten
	/// </summary>
	public static class StartUpExtensions
	{

		/// <summary>
		/// Register Winauth Middleware
		/// </summary>
		/// <param name="app">AppBuilder</param>
		public static void UseWinauth(this IAppBuilder app)
		{
			WinAuthConfig.Register(ref app);
		}


		/// <summary>
		/// Register WebApi Middleware
		/// </summary>
		/// <param name="app">AppBuilder</param>
		/// <param name="config">Konfiguration für die Api</param>
		public static void UseWebApi(this IAppBuilder app, ref HttpConfiguration config)
		{
			WebApiConfig.Register(ref app, ref config);
		}


		/// <summary>
		/// Register Dependencies (initialize AutoFac)
		/// </summary>
		/// <param name="app">AppBuilder</param>
		/// <param name="config">Konfiguration for the Api</param>
		/// <param name="builder">AutoFac ContainerBuilder</param>
		public static void RegisterDependencies(this IAppBuilder app, ref HttpConfiguration config, ref ContainerBuilder builder)
		{
			DependencyConfig.Register(ref app, ref config, ref builder);
		}

	}

}