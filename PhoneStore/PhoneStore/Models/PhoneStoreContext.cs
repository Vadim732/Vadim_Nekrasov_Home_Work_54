using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models;

public class PhoneStoreContext: DbContext
{
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Review> Reviews { get; set; }
    
    public PhoneStoreContext(DbContextOptions<PhoneStoreContext> options) : base(options) {}
}