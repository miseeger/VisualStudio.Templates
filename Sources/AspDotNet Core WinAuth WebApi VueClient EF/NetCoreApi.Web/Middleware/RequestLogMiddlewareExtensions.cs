using Microsoft.AspNetCore.Builder;

namespace $safeprojectname$.Middleware
{

    public static class RequestLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogMiddleware>();

        }
    }

}
