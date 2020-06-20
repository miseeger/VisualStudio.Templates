using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace $safeprojectname$.Middleware
{
    public class $ext_safeprojectname$PingMiddleware
    {
        private readonly RequestDelegate _next;

        public $ext_safeprojectname$PingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/ping"))
            {
                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Don't bug me!");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
