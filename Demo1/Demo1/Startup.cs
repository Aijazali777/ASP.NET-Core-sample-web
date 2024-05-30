using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Demo1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            //MiddleWare
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*
            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("welcome.html")
            app.UseDefaultFiles(defaultFilesOptions);
            */

            app.UseStaticFiles();
            //  app.UseMvcWithDefaultRoute();

            #region Conventional Routing
            /* app.UseMvc(routes =>
             {
                 routes.MapRoute("default", "{controller}/{action}/{id?}");
             });*/
            #endregion

            #region For Routing it will use attribute routing
            app.UseMvc();
            #endregion

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Aijaz");
            });

            #region logger midlleware
            /*
            app.Use(async (context, next) =>
            {
                // await context.Response.WriteAsync("Hello World!, I am from 1st middleware!\n");
                logger.LogInformation("MW1: Incoming request!");
                await next(); //It is a delegate "next"
                logger.LogInformation("NM1: Outgoing request!");
            });

            app.Use(async (context, next) =>
            {
                // await context.Response.WriteAsync("Hello World!, I am from 1st middleware!\n");
                logger.LogInformation("MW2: Incoming request!");
                await next(); //It is a delegate "next"
                logger.LogInformation("NM2: Outgoing request!");
            });*/
            #endregion

            #region RUN method (Adds a terminating middleware)
            // MiddleWare that response every request
            /*   app.Run(async (context) =>
               {
                   await context.Response.WriteAsync("MW3: process request successfully and generated response!");
                   logger.LogInformation("MW3: process request successfully and generated response!");
               }
               );*/
            #endregion
        }
    }
}
