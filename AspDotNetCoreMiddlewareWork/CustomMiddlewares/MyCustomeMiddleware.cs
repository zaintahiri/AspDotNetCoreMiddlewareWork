namespace AspDotNetCoreMiddlewareWork.CustomMiddlewares
{
    public class MyCustomeMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\nThis is my custom middleware class");
            await context.Response.WriteAsync("\nBefore next middleware started");
            await next(context);
            await context.Response.WriteAsync("\nafter next middleware finished");
        }

        
    }

    public static class CustomeMiddlewareExtension
    {
        public static IApplicationBuilder MyCustomeMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomeMiddleware>();
        }
    }
}
