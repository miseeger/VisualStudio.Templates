using Microsoft.AspNetCore.Builder;

namespace $safeprojectname$.Middleware
{

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogMiddleware>();

        }

        public static IApplicationBuilder Use$ext_safeprojectname$Ping(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<$ext_safeprojectname$PingMiddleware>();
        }
    }

}
