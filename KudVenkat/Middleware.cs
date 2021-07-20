using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudVenkat
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        
        public Middleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;
            _logger = logFactory.CreateLogger("My Middleware");
        }

        /* A Middleware needs to have either Invoke or InvokeAsync methods*/
        public Task Invoke(HttpContext httpContext)
        {
            return _next(httpContext);
        }

        /*
        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
        }
        */
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
