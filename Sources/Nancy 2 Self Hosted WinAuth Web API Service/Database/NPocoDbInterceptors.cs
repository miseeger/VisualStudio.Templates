using System;
using $safeprojectname$.Interfaces;
using NPoco;

namespace $safeprojectname$.Database
{

    public class NPocoDbInterceptors : IDataInterceptor
	{

		public bool OnInserting(IDatabase database, InsertContext insertContext)
		{
            var poco = insertContext.Poco; // ggfs. casting

            if (poco != null)
		    {
                // ...
		    }

			return true;
		}


		public bool OnUpdating(IDatabase database, UpdateContext updateContext)
		{
            var poco = updateContext.Poco; // ggfs. casting

            if (poco != null)
            {
                // ...
            }

            return true;

		}


		public bool OnDeleting(IDatabase database, DeleteContext deleteContext)
		{
			var context = deleteContext;
			return true;

		}

    }

}