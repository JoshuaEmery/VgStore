using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using VgWebApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using VgWebApp.Models;

namespace VgWebApp
{
    public class Startup
    {
        //Startup constructor which pulls in a configuration file
        //via DI, it pulls the configuration from appsettings.json
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;
        //This object will store the appsettings and be available to the
        //rest of the startup class
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //This adds the dbcontext to the services and configures the
            //options to UseSqlServer as well as pulls data from the 
            //appsettings.json regarding the connection string
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:VgStoreProducts:ConnectionString"]));
            //Any constructor in the project can not request an IProductRepository
            //and it will be given an object of type EFProductRepository
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp)); //NEW
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //NEW
            //this adds the MVC service to the services collection
            services.AddMvc();
            services.AddMemoryCache(); /* NEW */
            services.AddSession(); /* NEW */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //This displays a more detailed page when an exception is thrown
            //should b removed before deployment
            app.UseDeveloperExceptionPage();
            //This adds status codes to http responses such as 404
            app.UseStatusCodePages();
            //This allows static files to be served from wwwroot
            app.UseStaticFiles();
            //Enables session state for applications
            app.UseSession();

            //This sets the default pad to /Product/List
            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //    name: "pagination",
            //    template: "Products/Page{productPage}",
            //    defaults: new { Controller = "Product", action = "List" });
            //    routes.MapRoute(
            //    name: "default",
            //    template: "{controller=Product}/{action=List}/{id?}");
            //});

            //When I had changed the string category to genre, I also had to change
            //or replace the references to that string to genre in the template section of
            //routes.MapRoute
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "{genre}/Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List" }
                );

                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "{genre}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                );

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });
            //Send the app object to the ensure populated method.
            //This whill check to see if there is data in the database, if
            //not then it will seed it with data
            SeedData.EnsurePopulated(app);
        }
    }
}
