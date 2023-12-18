public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<SecondMiddleware>();

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseStaticFiles();
        app.UseRouting();
        app.UseEndpoints((endpoints)=>
        {
            endpoints.MapGet("/", async (context)=>
            {
                await context.Response.WriteAsync("Trang chu");
            });
            endpoints.MapGet("/abc.html", async (context)=>
            {
                await context.Response.WriteAsync("Trang gioi thieu");
            });
        });
        app.Map("/admin", (IApplicationBuilder app1)=>
        {
            app1.UseRouting();
            app1.UseEndpoints((endpoints)=>
            {
                endpoints.MapGet("/product", async (context)=>
                {
                    await context.Response.WriteAsync("Trang san pham");
                });
            });
            app1.Run(async (context)=>
            {
                await context.Response.WriteAsync("Trang thong tin");
            });
        });

    }
}