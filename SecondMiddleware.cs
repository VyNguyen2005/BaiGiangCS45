public class SecondMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if(context.Request.Path == "xxx.html")
        {
            var datafromFirstMiddleware = context.Items["DataFirstMiddleware"];
            if(datafromFirstMiddleware != null)
            {
                await context.Response.WriteAsync((string)datafromFirstMiddleware);
                await context.Response.WriteAsync("Ban khong duoc truy cap");
            }
            else
            {
                datafromFirstMiddleware = context.Items["DataFirstMiddleware"];
                if(datafromFirstMiddleware != null)
                await context.Response.WriteAsync((string)datafromFirstMiddleware);
                await next(context);

            }
            
        }
    }
}