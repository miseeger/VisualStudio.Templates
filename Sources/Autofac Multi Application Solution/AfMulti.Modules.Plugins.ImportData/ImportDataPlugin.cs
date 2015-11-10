using System;
using AutofacModularity.Interfaces;
using DotLiquid.Mailer;

namespace $safeprojectname$
{

public class ImportDataPlugin : IPlugin
	{

		private IMailEngine _mailer;


        public ImportDataPlugin(IMailEngine mailer)
        {
            _mailer = mailer;
        }


        public void Run(string[] args)
        {
            Console.WriteLine("ImportData-Plugin: ready");

            var data = new
            {
                Name = "Mr. Doe",
                ProductUri = "https://www.visualstudio.com/products/visual-studio-community-vs"
            };

            _mailer.SendFromFile("Data was imported", "ImportDataMail.liquid.html", data, "a.b@c.de");

            Console.WriteLine("Mail sent.");
        }

	}

}
