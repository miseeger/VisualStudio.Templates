using System;
using System.Configuration;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace $safeprojectname$
{
	public class WebApiHubService : ServiceBase
	{
		public static string WebServiceName = "$safeprojectname$";
		public static string WebServiceDescription = "Main WebApi Service for modular WebApis";
		public static string BasePort = ConfigurationManager.AppSettings["Apps.WebApi.Hub.BasePort"];

		private IDisposable _server = null;


		public WebApiHubService()
		{
			this.ServiceName = WebServiceName;
		}
		

		protected override void OnStart(string[] args)
		{
			var options = new StartOptions();

			options.Urls.Add(String.Format("http://localhost:{0}", BasePort));
			options.Urls.Add(String.Format("http://127.0.0.1:{0}", BasePort));
			options.Urls.Add(string.Format("http://{0}:{1}", Environment.MachineName, BasePort));

			options.ServerFactory = "Microsoft.Owin.Host.HttpListener";

			_server = WebApp.Start<Startup>(options);
		}


		protected override void OnStop()
		{
			if(_server != null)
			{
				_server.Dispose();
			}
			base.OnStop();
		}		 
	}
}