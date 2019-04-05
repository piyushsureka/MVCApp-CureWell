﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickKartDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
//using Infosys.DBFirstCore.DataAccessLayer.Models;
using AutoMapper;
using QuickKartCoreMVCApp.Repository;




namespace QuickKartCoreMVCApp
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
            services.AddSession();

            services.AddHttpContextAccessor();
            services.AddMvc();
            services.AddAutoMapper(x => x.AddProfile(new QuickKartMapper()));
            var connection = Configuration.GetConnectionString("QuickKartDBConnectionString");
            services.AddDbContext<QuickKartContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<QuickKartContext>(options => options.UseSqlServer(Configuration.GetConnectionString("QuickKartDBConnectionString")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Login}/{id?}");

                routes.MapRoute(
                    name: "User",
                    template: "{controller=User}/{action=RegisterUser}/{id?}");






            });
        }
    }
}
