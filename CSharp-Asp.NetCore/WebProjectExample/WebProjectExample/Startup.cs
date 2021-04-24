using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebProjectExample.Data;
using WebProjectExample.Filters;
using WebProjectExample.ModelBinders;
using WebProjectExample.RouteConstraints;
using WebProjectExample.Services;

namespace WebProjectExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>
                (options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>();

            //Added custom constraint
            services.AddRouting(options =>
            {
                options.ConstraintMap.Add("cyrillic", typeof(CyrillicRouteConstraints));
            });

            //This is how we register filters Globally
            services.AddControllersWithViews(configure =>
            {
                configure.Filters.Add(new MyAutFilter());
                configure.Filters.Add(new MyExceptionFilter());
                configure.Filters.Add(new MyResourceFilter());
                configure.Filters.Add(new MyResultFilterAttribute());
                configure.ModelBinderProviders.Insert(0, new ExtractYearModelBinderProvider());
            }).AddXmlSerializerFormatters(); //With AddXmlSerializerFormatters we activate to return XML as a response in the body

            services.AddTransient<IShortStringService, ShortStringService>();
            services.AddTransient<IInstanceCounter, InstanceCounter>();

            //If we have dependency container [TypeFilter(typeof(AddHeaderActionFilterAttribute))] 
            //we have to register the filter with singleton in order to have only one instance for the whole
            //lifecycle of the app to avoid duplication
            services.AddSingleton<AddHeaderActionFilterAttribute>();
            services.AddControllersWithViews();
            services.AddRazorPages();


            // Register Cache services IMemoryCache
            services.AddMemoryCache();
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                options.SchemaName = "dbo";
                options.TableName = "CacheRecords";
            });

            // if we want to use session we have to register also AddDistributedSqlServerCache
            services.AddSession(options =>
            {
                // Tells how much to save the cookie
                options.IOTimeout = new TimeSpan(356, 0, 0, 0);
                //This setting tells to the browser to do not show the cookie if someone wants to see it with JS
                options.Cookie.HttpOnly = true;
                // This session cookie is essential and don't need to ask the user to save it
                options.Cookie.IsEssential = true;
                //add middleware -> check before the routing
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //In this method we register all Middleware which have to be registered

            //new ApplicationDbContext().Database.Migrate(); we register the migrate method here

            ////Catch exception in development mode
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseDatabaseErrorPage();
            //}
            //else
            //{
            //    //Catch exception in production mode and show the proper Home/Error page to the user
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //This method takes the exception and send it to the Home/StatusCodeError page with the proper value
            app.UseStatusCodePagesWithRedirects("/Home/StatusCodeError?errorCode={0}");

            app.UseHttpsRedirection();//use https
            app.UseStaticFiles();//use static files

            app.UseRouting();//use routing

            app.UseAuthentication();//use user authentication -> related to who is the user -> Who
            app.UseAuthorization();//use user authorization -> related to the user roles and permissions -> What
            app.UseSession();// use session (register the session in the middleware)

            //Its related to register the pattern of the routs
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "areaRoute",
                    "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //This is how to create custom route
                endpoints
                    .MapControllerRoute("blogArticle", "Blog/{year}/{month}/{day}",
                    new { controller = "Home", action = "privacy" },
                    new { year = @"[0-9]{4}", month = @"[a-zA-Z]{3}", day = @"[0-9]{2}" });


                endpoints.MapRazorPages();
            });
        }
    }
}
