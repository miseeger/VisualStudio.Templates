using NPoco;

namespace $safeprojectname$.Data
{

    public class DataServiceInterceptors : IDataInterceptor
    {

        public bool OnInserting(IDatabase database, InsertContext insertContext)
        {
            var poco = insertContext.Poco; // cast if necessary

            if (poco != null)
            {
                // ...
            }

            return true;
        }


        public bool OnUpdating(IDatabase database, UpdateContext updateContext)
        {
            var poco = updateContext.Poco; // cast if necessary

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
