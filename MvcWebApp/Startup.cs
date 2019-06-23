using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisnessLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcWebApp.SignalHub;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace MvcWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<BL>();
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "SwaggerUI", Version = "v1" }); }); //Swagger
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Log.Logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(Configuration)
                            .Enrich.WithMachineName().CreateLogger();

            app.UseStaticFiles();
            app.UseSignalR(routes => routes.MapHub<ChatHub>("/chat"));
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //Setting Swagger up for testing Api`s from browser
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "MvcProj - v1"); });
        }
    }
}
