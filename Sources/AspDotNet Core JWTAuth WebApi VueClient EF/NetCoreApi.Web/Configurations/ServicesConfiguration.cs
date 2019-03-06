using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using $ext_safeprojectname$.Core.Data.Manager;
using $ext_safeprojectname$.Core.Data.Repositories;
using $ext_safeprojectname$.Core.Services;
using WebAPICore5.Core.Services;
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureCoreServices(this IServiceCollection services)
	{
            services.AddTransient<IEmailSender, SmtpMailer>();

	    return services;
	}
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAlbumRepository, AlbumRepository>()
                .AddScoped<IArtistRepository, ArtistRepository>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IGenreRepository, GenreRepository>()
                .AddScoped<IInvoiceRepository, InvoiceRepository>()
                .AddScoped<IInvoiceLineRepository, InvoiceLineRepository>()
                .AddScoped<IMediaTypeRepository, MediaTypeRepository>()
                .AddScoped<IPlaylistRepository, PlaylistRepository>()
                .AddScoped<ITrackRepository, TrackRepository>();

            return services;
        }

        public static IServiceCollection ConfigureDataManager(this IServiceCollection services)
        {
            services.AddScoped<IDataManager, DataManager>();

            return services;
        }

        public static IServiceCollection AddMiddleware(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            return services;
        }

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>        
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .Build());
            });
    }
}