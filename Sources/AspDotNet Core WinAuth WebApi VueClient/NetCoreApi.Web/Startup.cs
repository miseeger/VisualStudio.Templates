using System;
using System.IO;
using System.Reflection;
using System.Text;
using $ext_safeprojectname$.Core.Data;
using $safeprojectname$.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace $safeprojectname$
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostEnvironment { get; }


        public Startup (IConfiguration configuration, IHostingEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            // Enable Authentication via IIS (e. g. Windows Authentication)
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<$ext_safeprojectname$Context>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Db1"]);
            });

            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(Environment.CurrentDirectory, xmlFile);

                c.SwaggerDoc("v1", new Info
                {
                    Title = "$ext_safeprojectname$ API",
                    Version = "v1",
                    Description = "$ext_safeprojectname$",
                    TermsOfService = "EhDa",
                    Contact = new Contact { Name = "Mc Admin", Email = "mc.admin@coorp.com", Url = "" }
                });
                c.IncludeXmlComments(xmlPath);
                c.DescribeAllEnumsAsStrings();
            });
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(
                    async context =>
                    {
                        var loggerFactory = app.ApplicationServices.GetService<ILogger>();

                        if (loggerFactory != null)
                        {

                            context.Request.EnableRewind();
                            context.Request.Body.Position = 0;

                            using (var reader = new StreamReader(context.Request.Body, 
                                Encoding.UTF8, true, 1024, true))
                            {
                                var body = await reader.ReadToEndAsync().ConfigureAwait(false);
                                var exceptionHandler = context.Features
                                    .Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();

                                loggerFactory.LogError(exceptionHandler.Error, 
                                    "Error: {0}. Request: {1}", 
                                    exceptionHandler.Error.Message, body);
                            }

                        }

                    }
                );
            });

            app.UseRequestLogging();

            if (env.IsDevelopment())
            {
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ConfigFile = Path.Combine(env.ContentRootPath, @"VueClient\node_modules\@vue\cli-service\webpack.config.js"),
                    ProjectPath = Path.Combine(env.ContentRootPath, "VueClient")
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(builder =>
                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials());

            app.UseHttpsRedirection();
            app.UseStaticFiles();

        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        });

        // here you can see we make sure it doesn't start with /api, if it does, it'll 404 within .NET if it can't be found
        app.MapWhen(x => (!x.Request.Path.Value.StartsWith("/api") 
            && !x.Request.Path.Value.StartsWith("/swagger")), builder =>
        {
            builder.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "$safeprojectname$");
            });
        }
    }
}
