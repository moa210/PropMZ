namespace PropMZ
{
    using Areas.Identity.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Models;
    using Services;

    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                                                                options.UseSqlite(
                                                                        Configuration.GetConnectionString(
                                                                                "DefaultConnection")));
            // services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //         .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ApplicationIdentityDbContext>();
            services.AddControllersWithViews();

            // requires
            // using Microsoft.AspNetCore.Identity.UI.Services;
            // using PropMZ.Services;
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                             {
                                 endpoints.MapControllerRoute(
                                         "default",
                                         "{controller=Home}/{action=Index}/{id?}");
                                 endpoints.MapRazorPages();
                             });
        }
    }
}
