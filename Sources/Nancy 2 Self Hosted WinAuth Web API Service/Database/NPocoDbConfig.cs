using $safeprojectname$.Database;
using NPoco;
using NPoco.FluentMappings;
using $safeprojectname$.Database.Mapping;

namespace $safeprojectname$.Database
{

    /// <summary>
    /// Stellt spezielle Konfigurationen für ausgewählte
    /// Mapping-Szenarien bereit
    /// </summary>
    public class NPocoDbConfig
    {
        public static DatabaseFactory DbFactory { get; set; }

        public static void Initialize()
        {
            var fluentConfig = FluentMappingConfiguration.Configure
            (
                // new CostumeMapping()
            );

            DbFactory = DatabaseFactory.Config(x =>
            {
                x.WithFluentConfig(fluentConfig);
                x.WithInterceptor(new NPocoDbInterceptors());
            });
        }
    }
}