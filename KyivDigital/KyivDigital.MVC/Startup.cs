using KyivDigital.Business.Services.Implementations;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.MVC.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KyivDigital.MVC
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddTransient<IClaimsProvider, ClaimsProvider>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddHttpClient<IAuthenticationService, AuthenticationService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IHeadLineService, HeadLineService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IFeedService, FeedService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<ITravelCardService, TravelCardService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IBankCardService, BankCardService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });
            services.AddHttpClient<IFaqService, FaqService>(client =>
            {
                client.InitializationKyivDigitalClient();
            });


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/identity/login");
                });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
