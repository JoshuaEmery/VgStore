using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using VgWebApp.Data;

namespace VgWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //this registers the fakeproductrepository to the services collection
            //which makes it available via dependency injection.
            //Using addtransient means that a new FakeRepository object is created for
            //each request.
            services.AddTransient<IProductRepository, FakeProductRepository>();
            //this adds the MVC service to the services collection
            services.AddMvc();
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
            //This sets the default pad to /Product/List
            app.UseMvc(routes => {
                routes.MapRoute(
                name: "default",
                template: "{controller=Product}/{action=List}/{id?}");
            });
        }
    }
}
