using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using $ext_safeprojectname$.Core.Data;
using $ext_safeprojectname$.Core.Data.Interface;
using $ext_safeprojectname$.Core.Interface;
using $ext_safeprojectname$.Core.Service;
using $ext_safeprojectname$.Web.Middleware;

namespace $safeprojectname$
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ----- Localization

            // https://stackoverflow.com/questions/39006690/asp-net-core-request-localization-options
            // https://stackoverflow.com/questions/40442444/set-cultureinfo-in-asp-net-core-to-have-a-as-currencydecimalseparator-instead

            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("de-DE")
                // ,new CultureInfo("en-US")
            };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("de-DE");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.FallBackToParentCultures = true;
                options.FallBackToParentUICultures = true;
            });

            services.AddLocalization();

            // ----- CORS
            services.AddCors(options =>
            {
                // .AllowAnyOrigin() doesn't work atm.
                // .AllowAnyMethod() doesn't work for DELETE atm.

                if (Configuration["Cors:AllowedOrigins"] == "*")
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder
                            .SetIsOriginAllowed(s => true)
                            .WithMethods("GET", "POST", "DELETE", "OPTIONS", "PUT")
                            .AllowAnyHeader()
                            .AllowCredentials()
                    );
                }
                else
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder
                            .WithOrigins(string.Join(",", Configuration["Cors:AllowedOrigins"]))
                            .WithMethods("GET", "POST", "DELETE", "OPTIONS", "PUT")
                            .AllowAnyHeader()
                            .AllowCredentials()
                    );
                }
            });

            // ----- SPA Client
            services.AddSpaStaticFiles(configuration =>
                configuration.RootPath = Configuration["ClientApp:RootPath"]
            );

            // ----- Web API (with JSON)
            services.AddControllers().AddNewtonsoftJson();

            // ----- Core Services
            services.AddSingleton<IMailerService>(ms =>
                new MailerService(Configuration["Mailer:SmtpServer"], int.Parse(Configuration["Mailer:SmtpPort"]),
                    Configuration["Mailer:TemplateDir"], Configuration["Mailer:DefaultFrom"])
            );

            // ----- Data Services
            services.AddScoped<IDataService>(ds =>
                new DataService(Configuration["ConnectionStrings:NorthwindSqlite"])
            );

            // ----- Business Services
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddScoped<ICustomerService, CustomerService>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLocalization(
                app.ApplicationServices
                    .GetService<IOptions<RequestLocalizationOptions>>().Value
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(options =>
                {
                    options.Run(
                        async context =>
                        {
                            var loggerFactory =
                                app.ApplicationServices.GetService<ILogger>();

                            if (loggerFactory != null)
                            {
                                context.Request.EnableBuffering();
                                context.Request.Body.Position = 0;

                                using (var reader = new StreamReader(context.Request.Body,
                                    Encoding.UTF8, true, 1024, true))
                                {
                                    var body = await reader
                                        .ReadToEndAsync()
                                        .ConfigureAwait(false);
                                    var exceptionHandler = context.Features
                                        .Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();

                                    loggerFactory
                                        .LogError(exceptionHandler.Error, "Error: {0}. Request: {1}",
                                            exceptionHandler.Error.Message, body);
                                }
                            }
                        }
                    );
                });

                app.UseHsts();
            }

            app.UseRequestLogging();
            app.UseHttpsRedirection();
            app.Use$ext_safeprojectname$Ping();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = (Configuration["ClientApp:RootPath"]).Replace("/dist", string.Empty);

                if (env.IsDevelopment() && System.Diagnostics.Debugger.IsAttached)
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
