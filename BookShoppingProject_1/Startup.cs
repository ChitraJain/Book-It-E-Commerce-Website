using BookShoppingProject_1.Data;
using BookShoppingProject_1.DataAccess.Repository;
using BookShoppingProject_1.DataAccess.Repository.IRepository;
using BookShoppingProject_1.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShoppingProject_1
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<ICoverTypeRepository, CoverTypeRepository>();

            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //  .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
              .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                options.LogoutPath = $"/Identity/Account/Logout";
            });
            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "469831868299981";
                options.AppSecret = "7e442e23c8106fc4074809efc2827fdd";
            });
            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "37790569273-naahnpbsdl2tmbttf81131ohvt85oema.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            StripeConfiguration.ApiKey= Configuration.GetSection("Stripe")["SecretKey"];
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
