using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KudVenkat.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KudVenkat
{
    public class Startup
    {
        private IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddXmlSerializerFormatters(); //Will simply add the MVC as a Service to dotnet Core
            services.AddMvc(x => x.EnableEndpointRouting = false); //In .NET 3.0, EndPoints was introduced. So, if ever we have to use UseMvcWithDefaultRoute then we need to make EnableEndpointRouting to be false.

            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>(); //Creates a Singleton Service for the whole application
            
        }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                /*
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions {
                    SourceCodeLineCount = 10
                };
                */
                app.UseDeveloperExceptionPage();
            }

            if(env.IsStaging())
            {
                //app.UseExceptionHandler("/Error");
            }

            if(env.IsProduction())
            {
                //app.UseExceptionHandler("/Error");
            }

            app.UseMvcWithDefaultRoute();
            
            //Runs matching. An endpoint is selected and set on the HttpContext if a match is found.
            app.UseRouting();
            
            //Middleware that occurs after the routing occurs. Usually the following appear here:
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();
            //These middleware can take different actions based on the endpoint.

            app.Run(async (context) => await context.Response.WriteAsync("Hello World. This is just Testing the MVC Middleware.") );
            /*
            //Executes the endpont that was selected by Routing.
            app.UseEndpoints(endpoints =>
            {
                //Mapping of the endpoints goes here:
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapGet("/", async context =>
                {                    
                    await context.Response.WriteAsync("Hosting from: " + env.EnvironmentName + "\n");
                    await context.Response.WriteAsync("Hello World!");
                    //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                });
            });
            */
            /*I am commenting the below code considering the above concept of Environmental Variables */

            /* 
            DefaultFilesOptions defaultFileOptions = new DefaultFilesOptions();
            defaultFileOptions.DefaultFileNames.Clear();
            defaultFileOptions.DefaultFileNames.Add("foo.html");

            app.UseDefaultFiles(defaultFileOptions);
            app.UseStaticFiles();
            app.UseMiddleware<Middleware>();

            app.UseWelcomePage();
            app.Use(async (context, next) => 
            {
                logger.LogInformation("MW1: Incoming Request");
                await next();
                logger.LogInformation("MW1: Outgoing Response");
            }
            );

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2: Incoming Request");
                await next();
                logger.LogInformation("MW2: Outgoing Response");
            });
            //app.Use(async (context, next) => { await context.Response.WriteAsync("Hello Yashwanth. This is 1st Middleware"); await next(); });
            app.Run(async (context) => {
                //throw new Exception("Some error while processing ");
                await context.Response.WriteAsync("Yoo Bro. This is the Terminal Middleware."); 
            });
            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hi Yashwanth. This is 1st MiddleWare");
                await next();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hi Yashwanth. This is 2nd MiddleWare");
            });
            
            app.UseStaticFiles();
            */
        }
    }
}
