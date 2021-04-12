using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASPnetCoreMiddlewareDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //to go in this middleware you have to open /softuni and you will open the welcomePage from the app
            app.Map("/softuni", app =>
            {
                app.UseWelcomePage();
            });

           
            app.Map("/softuniNew", app =>
            {
                //to go in this middleware you have to open /softuniNew/Welcome and you will open the welcomePage from the app
                app.Map("/welcome", app => app.UseWelcomePage());

                //to go in this middleware you have to open /softuniNew/....(some path) to open the text bellow
                app.Run((request) => request.Response.WriteAsync("This is not the proper site!"));
            });


            //This How we create middleware with custom class
            app.UseMiddleware<EveryTwoSecondsMiddleware>();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello - 1!! ");
                await next();
                await context.Response.WriteAsync("Hello - 2!! ");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello - 2!! ");
                await next();
                await context.Response.WriteAsync("Hello - 3!! ");
            });

            app.Run(async (request) => //Run method should be on last place, because after it the code will not continue down
            {
                await request.Response.WriteAsync("/ I`m the request / ");
            });

            //This code is unreachable because of app.Run middleware
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello - 5!! ");
                await next();
                await context.Response.WriteAsync("Hello - 6!! ");
            });

            //Run and use have access to the https information, the difference is that USE has the method next() while after
            //.Rune will be the last middleware and after it`s execution the code will revert its flow back to the first middleware.
        }
    }
}

//async (context, next) => This is request delegate
//{
//    await context.Response.WriteAsync("Hello - 2!! ");
//    await context.Response.WriteAsync("Hello - 3!! ");
//})

//Middleware which we can reuse
public class EveryTwoSecondsMiddleware
{
    private readonly RequestDelegate next;

    public EveryTwoSecondsMiddleware(RequestDelegate next )
    {
        this.next = next;
    }

    //We can invoke here services from our app  public async Task InvokeAsync(HttpContext context, ISomeService someService)
    //and we can use it bellow in the method
    public async Task InvokeAsync(HttpContext context)
    {
        await context.Response.WriteAsync($"First -> {DateTime.UtcNow.Second} ");

        if (DateTime.Now.Second % 2 == 0)
        {
            await this.next(context);
        }

        await context.Response.WriteAsync($"Last -> {DateTime.UtcNow.Second} ");
    }
}