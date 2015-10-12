using System;
using System.Linq;
using System.Net;
using Autofac;
using AutofacModularity.Interfaces;
using $ext_safeprojectname$.Common.Interfaces.Services;
using NLog;

namespace $safeprojectname$
{
	public class Shell : IShell
	{
		
		private IComponentContext _container;
		private IDbDataService _dataService;
		private ILoggingService _logger;


		public Shell(IComponentContext container, IDbDataService dbDataservice, 
			ILoggingService logger)
		{
			_container = container;
			_dataService = dbDataservice;
			_logger = logger;
			_logger.SetName("$safeprojectname$");
		}


		private void CurrentDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs e)
		{
			try
			{
				Exception ex = (Exception)e.ExceptionObject;
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

			System.Console.WriteLine("\nRegistered Components ({0}):",
				_container.ComponentRegistry.Registrations.Count());

			foreach (var entry in _container.ComponentRegistry.Registrations)
			{
				System.Console.WriteLine("   {0}", entry.ToString().Split(',')[0]);
				_logger.Log(LogLevel.Info, String.Format("Registered: {0}", entry.ToString().Split(',')[0]));
			}

			_logger.SetName("DbLogger");
			var hostName = Dns.GetHostName();
			var ipAddress = Dns.GetHostByName(hostName).AddressList[0].ToString();
			GlobalDiagnosticsContext.Set("ipAddress", ipAddress);
			GlobalDiagnosticsContext.Set("program", "TestHost");
			GlobalDiagnosticsContext.Set("level", "4");
			GlobalDiagnosticsContext.Set("messageId", "99999");
			_logger.Log(LogLevel.Info, "Test von NLog ;-)");
			_logger.SetName("$safeprojectname$");


			System.Console.WriteLine("\nFrom DataService:");
			_dataService.Hello();

			System.Console.WriteLine("\nRunning CheckDataPlugin:");
			var cr = _container.ResolveNamed<IPlugin>("CheckDataPlugin");
			cr.Run(args);


			try
			{
				System.Console.WriteLine("\nRunning ImportDataPlugin:");
				var ir = _container.ResolveNamed<IPlugin>("ImportDataPlugin");
				ir.Run(args);
			}
			catch (Exception e)
			{
				System.Console.WriteLine(e);
			}

			System.Console.Write("\nPress any key to continue . . . ");
			System.Console.ReadKey(true);

		}

	}

}