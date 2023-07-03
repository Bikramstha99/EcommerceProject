using EcommerceApp.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data
{
    public class EcommerceDbContext : IdentityDbContext
{
        public EcommerceDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Ecommerce> Ecommerces { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
