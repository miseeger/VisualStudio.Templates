using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.Configuration;
using Nancy.Conventions;
using Nancy.Diagnostics;
using Nancy.TinyIoc;
using $safeprojectname$.Interfaces;
using $safeprojectname$.Services;

namespace $safeprojectname$
{

    public class AppBootstrapper : DefaultNancyBootstrapper
    {
        private IHostingEnvironment _hostingEnvironment;

        private IConfigurationRoot _configuration;

        public AppBootstrapper(IHostingEnvironment env)
        {
            _hostingEnvironment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(RootPathProvider.GetRootPath())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }


        public override void Configure(INancyEnvironment environment)
        {
            //Tracing and Diagnostics:
            //environment.Tracing(true, true);
            //environment.Diagnostics(true, "password");
            base.Configure(environment);
        }


        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);
            // ... your custom conventions go here ...
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Register<INPocoDbService, NPocoDbService>();
        }


        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<IConfiguration>(_configuration);
        }
    }

}