using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap.Manager;
using Bootstrap.Manager.IContract;
using Bootstrap.Repositories;
using Bootstrap.Repositories.Contract;
using Bootstrap1.Areas.Identity.Data;
using Bootstrap1.Utiliites;
using Bootstrap1.Utiliites.IUitilites;
using Bootstrapdb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrap1
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddTransient<DbContext, ProjectDbContext>();
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddTransient<ICategoriesManager, CategoriesManager>();
            services.AddTransient<ISubCategoriesRepository, SubCategriesRepository>();
            services.AddTransient<ISubCategoriesManger, SubCategoriesManger>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductManager, ProductManger>();
            services.AddTransient<IUtilitiesManager, DropDownUtilities>();
            services.AddDbContext<AplicationDbContext>(options =>
            {
                options.UseSqlServer("AplicationDbContextConnection");
            });
            services.AddDbContext<DbContext>(optionBuilder => { optionBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BootstrapDb;Integrated Security=true;"); });
            //services.AddDefaultIdentity<ApplicationUser>()
            //    .AddEntityFrameworkStores<AplicationDbContext>()
            //    .AddDefaultUI(UIFramework.Bootstrap4);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
