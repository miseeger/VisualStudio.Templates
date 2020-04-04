using $safeprojectname$.Data.Mapping;
using NPoco;
using NPoco.FluentMappings;

namespace $safeprojectname$.Data
{
    public class DataServiceConfig
    {
        public static DatabaseFactory DbFactory { get; set; }

        public static void Initialize()
        {
            var fluentConfig = FluentMappingConfiguration.Configure
            (
                new CustomerMapping()
            );

            DbFactory = DatabaseFactory.Config(x =>
            {
                x.WithFluentConfig(fluentConfig);
                x.WithInterceptor(new DataServiceInterceptors());
            });
        }
    }
}
