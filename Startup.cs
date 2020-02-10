using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DivaHair.Data;
using DivaHair.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DivaHair
{
    public class Startup
    {
        private readonly IConfiguration _config;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<HairContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("HairConnectionString"));
            });

            services.AddTransient<IMailService, NullMailService>();
            services.AddTransient<HairSeeds>();
            //Support for real maail service
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();

            app.UseMvc( cfg =>
            {
                cfg.MapRoute("Default", 
                    "{controller}/{action}/{id?}", 
                    new { controller = "App", Action = "Index" });
            });

            if (env.IsDevelopment())
            {
                // new HairSeeds()
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeds = scope.ServiceProvider.GetService<HairSeeds>();
                    seeds.Seed();
                }
            }
        }
    }
}
