namespace PropMZ.Models
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Migrations, UseAuthentication, and layout
        // https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-6.0&tabs=netcore-cli
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }
    }
}
