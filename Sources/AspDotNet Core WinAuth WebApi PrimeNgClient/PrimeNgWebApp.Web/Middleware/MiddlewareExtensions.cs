using Microsoft.AspNetCore.Builder;

namespace $safeprojectname$.Middleware
{

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogMiddleware>();

        }

        public static IApplicationBuilder UsePing(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PingMiddleware>();
        }
    }

}
