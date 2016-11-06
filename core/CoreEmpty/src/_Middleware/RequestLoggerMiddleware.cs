using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace _Middlewave
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("正在处理请求:" + httpContext.Request.Path);
            await _next(httpContext);
            await httpContext.Response.WriteAsync("请求处理完成");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
}
