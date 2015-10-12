using System;
using System.Linq;
using System.Net;
using Autofac;
using AutofacModularity.Interfaces;
using $ext_safeprojectname$.Common.Interfaces;
using $ext_safeprojectname$.Common.Interfaces.Services;
using NLog;

namespace $safeprojectname$
{
	public class Shell : IShell
	{
		
		private IComponentContext _container;
		private ILoggingService _logger;
		private IGlobalInfoService _globalInfo;


		public Shell(IComponentContext container, ILoggingService logger, IGlobalInfoService globalInfo)
		{
			_container = container;
			_logger = logger;
			_globalInfo = globalInfo;
			_logger.SetName("$safeprojectname$");
		}


		private void CurrentDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs e)
		{
			try
			{
				var ex = (Exception)e.ExceptionObject;
				_logger.LogEx("Unhadled domain exception!", ex);
			}
			catch (Exception exc)
			{
				_logger.LogEx("Exception inside UnhadledExceptionHandler!", exc);
			}
			finally
			{
				Environment.Exit(0);
			}
		}


		public void Run(string[] args)
		{

			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

			if (args != null && args.Length > 1)
			{
				if (_container.IsRegisteredWithName<IPlugin>(args[0]))
				{
					var plugin = _container.ResolveNamed<IPlugin>(args[0]);
					plugin.Run(
						args
							.Select(a => a)
							.Skip(1)
							.ToArray()
						);
				}
				else
				{
					var msg = String.Format("Das Plugin {0} ist im DI-Container nicht (als IPlugin) registriert (Tippfehler?).",
						args[0]);
					_logger.Log(LogLevel.Error, msg);
				}

			}
			else
			{
				_logger.Log(LogLevel.Warn,
					args == null
						? "Es wurden keine auswertbaren Parameter angegeben."
						: args.Length < 2
							? "Es wurden weniger als zwei Argumente angegeben (TaskRunner <Plugin> <Task>)."
							: "");
			}

		}

	}

}