using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceSchoolPortal.Data;
using AceSchoolPortal.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AceSchoolPortal
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<StoreUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                //cfg.Password.RequiredLength = 5;
                //cfg.Password.RequireNonAlphanumeric = true;
                //cfg.Password.RequiredUniqueChars = 2;
            })
                .AddEntityFrameworkStores<SchoolContext>();

            services.AddDbContext<SchoolContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("SchoolConnectionString"));
            });
            services.AddTransient<SchoolSeeder>();

            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddControllersWithViews();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();

            // the below methods are for the Identity management and important that it comes after routing and before endpoints
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Fallback",
                    "/{controller}/{action}/{id?}",
                    new { controller = "App", action = "Index" });
            });

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

        }
    }
}
