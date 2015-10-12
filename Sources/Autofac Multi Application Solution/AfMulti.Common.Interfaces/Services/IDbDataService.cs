using System;
using System.Collections.Generic;
using NPoco;

namespace $safeprojectname$.Services
{
	
	public interface IDbDataService : IDatabase
	{
	
		string CurrentUser { get; set; }
		List<string> GetActiveUsers();
		
		void Hello();

	}

}