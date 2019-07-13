using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using BOKWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BOKWebsite.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BOKWebsite
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            //Identity services


            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<EmployeeContext>();

            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequiredLength = 6;

            //    options.User.AllowedUserNameCharacters =
            //    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //});

            //add MVC
            services.AddMvc();

            services.AddDbContext<EmployeeContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BOKDatabaseContext")));

            services.AddScoped<NasaApiController, NasaApiController>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Employee}/{action=Index}/{id?}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MVC was not found! :-)");
            });
        }
    }
}
