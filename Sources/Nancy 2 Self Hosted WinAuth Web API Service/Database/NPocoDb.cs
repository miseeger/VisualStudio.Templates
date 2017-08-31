using System.Data.SqlClient;
using $safeprojectname$.Interfaces;
using NPoco;

namespace $safeprojectname$.Database
{

	public class NPocoDb : NPoco.Database, INPocoDb
	{

		public NPocoDb(string dbConnection)
			: base(new SqlConnection(dbConnection))
		{
			NPocoDbConfig.Initialize();
			NPocoDbConfig.DbFactory.Build(this);
		}

		public NPocoDb(string dbConnection, DatabaseType dbType)
			: base(new SqlConnection(dbConnection), dbType)
		{
			NPocoDbConfig.Initialize();
			NPocoDbConfig.DbFactory.Build(this);
		}

	}

}