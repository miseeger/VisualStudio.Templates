using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace $safeprojectname$
{

	[RunInstaller(true)]
	public class WebApiHubInstaller : Installer
	{

		private ServiceProcessInstaller serviceProcessInstaller;
		private ServiceInstaller serviceInstaller;

		public WebApiHubInstaller()
		{
			serviceProcessInstaller = new ServiceProcessInstaller();
			serviceInstaller = new ServiceInstaller();

			// Here you can set properties on serviceProcessInstaller or register event handlers
			//serviceProcessInstaller.Account = ServiceAccount.LocalService;
			serviceProcessInstaller.Account = ServiceAccount.User;

			serviceInstaller.ServiceName = WebApiHubService.WebServiceName;
			serviceInstaller.Description = WebApiHubService.WebServiceDescription;
			this.Installers.AddRange(new Installer[] { serviceProcessInstaller, serviceInstaller });
		}

	}

}