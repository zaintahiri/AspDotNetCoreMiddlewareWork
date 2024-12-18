namespace AspDotNetCoreMiddlewareWork.CustomMiddlewares
{
    public class ExtensionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(this WebApplication app,HttpContext context, RequestDelegate next)
        {
            
        }
    }
}
