using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Nancy.Owin;

namespace $safeprojectname$
{
    public class Startup
    {
        private IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(pipeline => 
            {
                pipeline.UseNancy(options => 
                {
                    options.Bootstrapper = new AppBootstrapper(_env);
                });
            });
        }

    }
    
}
