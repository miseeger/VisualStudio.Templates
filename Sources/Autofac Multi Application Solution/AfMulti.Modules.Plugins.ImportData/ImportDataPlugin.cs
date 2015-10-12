using System;
using AutofacModularity.Interfaces;
using EmailModule;

namespace $safeprojectname$
{

public class ImportDataPlugin : IPlugin
	{

		private IEmailSystem _mailer;
		
		
		public ImportDataPlugin(IEmailSystem Mailer)
		{
			_mailer = Mailer;
		}


		public void Run(string[] args)
		{
			Console.WriteLine("ImportData-Plugin: ready");
			
			var model = new 
			{
				To = "a.b@c.de"
				,From = ""
				,Name = "Mr. Doe"
				,VerificationUri = "https://www.visualstudio.com/products/visual-studio-community-vs"
			};

			_mailer.SendMail("ImportDataMail", model);

			Console.WriteLine("Mail sent.");

		}

	}

}
