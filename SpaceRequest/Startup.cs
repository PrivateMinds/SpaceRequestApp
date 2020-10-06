using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpaceRequestDataFactory;

namespace SpaceRequest
{
    public class Startup
    {
        //Create a variable of type IConfiguration
        public IConfiguration Configuration { get; }

        //Through constructor dependency injection, inject the IConfiguration object and store it within the your variable.
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddControllersWithViews();
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //UseSqlServer() extension method is used to configure our application specific DbContext class to use Microsoft    SQL Server as the database.
            // To connect to a database, we need the database connection string which is provided as a parameter to  UseSqlServer() extension method

            services.AddDbContextPool<AppDbContext>(options =>
            {
                //We store the connection string in the appsettings.json configuration file
                //To read connection string from appsettings.json file, we use IConfiguration service GetConnectionString()  method.
                options.UseSqlServer(Configuration.GetConnectionString("CHSHRPAYDBConnection"));
            });

            //We are using AddScoped() method because we want the instance to be alive 
            //and available for the entire scope of the given HTTP request.
            services.AddScoped<ISpaceRequestRepository, SQLSpaceRequestRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=SpaceRequest}/{action=Index}/{id?}");
            });
        }
    }
}
