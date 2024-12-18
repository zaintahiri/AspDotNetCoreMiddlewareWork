using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspDotNetCoreMiddlewareWork.CustomMiddlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomConventionalMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomConventionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.WriteAsync("Conventional Middleware is started");
            await  _next(httpContext);
            httpContext.Response.WriteAsync("Conventional Middleware is Finished");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomConventionalMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomConventionalMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomConventionalMiddleware>();
        }
    }
}
