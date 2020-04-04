using Microsoft.Data.Sqlite;
using $safeprojectname$.Data.Interface;
using NPoco;

namespace $safeprojectname$.Data
{
    // Uses SqliteConnection !!! Only for use with SQLite DB !!!

    public class DataService : NPoco.Database, IDataService
    {

        public DataService(string dbConnection)
            : base(new SqliteConnection(dbConnection))
        {
            DataServiceConfig.Initialize();
            DataServiceConfig.DbFactory.Build(this);
        }

        public DataService(string dbConnection, DatabaseType dbType)
            : base(new SqliteConnection(dbConnection), dbType)
        {
            DataServiceConfig.Initialize();
            DataServiceConfig.DbFactory.Build(this);
        }

    }

}
