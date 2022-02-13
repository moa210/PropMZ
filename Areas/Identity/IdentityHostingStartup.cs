using Microsoft.AspNetCore.Hosting;
using PropMZ.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace PropMZ.Areas.Identity
{
    using Data;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class IdentityHostingStartup : IHostingStartup
    {

        #region IHostingStartup Members
        public void Configure(IWebHostBuilder builder) =>
                builder.ConfigureServices((context, services) =>
                                          {
                                              services.AddDbContext<ApplicationIdentityDbContext>(options =>
                                                      options.UseSqlServer(
                                                              context.Configuration.GetConnectionString(
                                                                      "DefaultConnection")));
                                              // var connection = @"Server=localhost;Database=mssql;User=moa210;Password=Passw0rd!";
                                              // services.AddDbContext<ApplicationIdentityDbContext>(options =>
                                              //        options.UseSqlServer(connection));
                                          });
        #endregion

    }
}
