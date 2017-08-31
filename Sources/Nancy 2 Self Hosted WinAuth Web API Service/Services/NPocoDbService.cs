using NPoco;
using $safeprojectname$.Interfaces;
using $safeprojectname$.Database;
using Microsoft.Extensions.Configuration;

namespace $safeprojectname$.Services
{
public class NPocoDbService : INPocoDbService
	{

        private IConfiguration _config;

        public NPocoDbService (IConfiguration config)
        {
            _config = config;
        }

		// Provides an instance of a NPoco Database object which implements 
		// IDisposable and is ready to use in a using()-statment.
		public INPocoDb CreateDb()
        {
            return new NPocoDb(_config["ConnectionString"], DatabaseType.SqlServer2012);
        }

	}

}