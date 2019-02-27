using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.AppState
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
            services.Configure<CookiePolicyOptions>(options =>
            {
               
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
               
            });
            
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
            });

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie( options =>
            //{
            //    options.Cookie = new CookieBuilder
            //    {
            //        //Domain = "",
            //        HttpOnly = false,
            //        Name = "mykey",
            //        Path = "/",
            //        SameSite = SameSiteMode.Lax,
            //        SecurePolicy = CookieSecurePolicy.SameAsRequest
            //    };
            //    options.ExpireTimeSpan = TimeSpan.FromSeconds(1);
            //    options.LoginPath = new PathString("/Buy/Login");
            //    options.ReturnUrlParameter = "RequestPath";
            //    options.SlidingExpiration = true;
            //});
            services.AddAuthentication("mykey").AddCookie("mykey", options => {
                
                options.Cookie.Name = "mykey";
               
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromSeconds(1);
                
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
