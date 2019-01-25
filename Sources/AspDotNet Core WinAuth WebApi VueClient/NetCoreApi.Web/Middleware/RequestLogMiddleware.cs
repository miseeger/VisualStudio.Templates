using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace $safeprojectname$.Middleware
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLogMiddleware(RequestDelegate next, ILogger<RequestLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();

            await _next(context);

            stopwatch.Stop();

            _logger.LogTrace(
                $"Result code: {context.Response.StatusCode}; Method: {context.Request.Method}; Path: {context.Request.Path}; Execution time: {stopwatch.ElapsedMilliseconds}[ms]");
        }
    }
}
