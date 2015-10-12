
using System;
using AutofacModularity.Interfaces;

namespace $safeprojectname$
{

	public class CheckDataPlugin : IPlugin
	{

		private String Test { get; set; }

		public CheckDataPlugin(String test)
		{
			Test = test;	
		}

		public void Run(string[] args)
		{
			Console.WriteLine("CheckData-Plugin: ready ({0})", Test);
		}

	}

}