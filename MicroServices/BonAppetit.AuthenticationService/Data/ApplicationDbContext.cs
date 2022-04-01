using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.ApplicationUserModels;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        //Tables
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}