using System;
using System.Collections.Generic;
using AutofacModularity;
using $ext_safeprojectname$.Common.Base.Utils;
using $ext_safeprojectname$.Common.Interfaces.Services;
using NPoco;

namespace $safeprojectname$
{

	[RegisterService]
	public class DbDataService : Database, IDbDataService
	{

		public string CurrentUser { get; set; }

			
		public DbDataService(string dbActiveConnection)
			: base(dbActiveConnection)
		{
			InitService();		
		}

		public DbDataService(string dbActiveConnection, DatabaseType dbActiveDatabaseType)
			: base(dbActiveConnection, dbActiveDatabaseType)
		{
			InitService();
		}
		
		
		private void InitService()
		{
			CurrentUser = SystemEnvironment.CurrentUser;
		}
		
		
		public void Hello()
		{
			Console.WriteLine("Hello from DbDataService ...");
		}
		
		
		public List<string> GetActiveUsers()
		{
			return new List<string> {SystemEnvironment.CurrentUser};

		}
		
	}

}
