

using AspDotNetCoreMiddlewareWork.CustomMiddlewares;

// here we are creating object of the WebBuilderClass, CreateBuilder returns object of the WebBuilder Class
var builder = WebApplication.CreateBuilder(args);

// Register middleware as service, it follows the dependency injection
builder.Services.AddTransient<MyCustomeMiddleware>();

// here we are creating object of the WebApplication
var app = builder.Build();

//By using app.Use or app.Run method we are able to call middlewares
// Middleware is nothing is lamda expression, callback funtion
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("First Middleware is called");
    await next(context);
});

app.Use(async (HttpContext context,RequestDelegate next) =>
{
        await context.Response.WriteAsync("Second middleware is called");
        await next(context);
});

// here i have called my custom middleware which injected in the program class using builder object
// builder.Services.AddTransient<MyCustomeMiddleware>(); // this line registers MyCustomeMiddleware as service
//app.UseMiddleware<MyCustomeMiddleware>();
app.MyCustomeMiddleware();

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("\nAnother Middleware called after custom middleware ");
});

app.Run();
