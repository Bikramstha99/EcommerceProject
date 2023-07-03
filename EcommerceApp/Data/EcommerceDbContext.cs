using EcommerceApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Ecommerce> Ecommerces { get; set; }
    }
}
