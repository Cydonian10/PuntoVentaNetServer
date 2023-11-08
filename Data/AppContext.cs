using Microsoft.EntityFrameworkCore;

namespace ApiStore.Data;

public class ApplicationContext : DbContext
{
    public DbSet<AuthUser>? Auths { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Customer> Cutomers { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<Provider>? Providers { get; set; }
    public DbSet<Shopping>? Shoppings { get; set; }
    public DbSet<ShoppingItem>? ShoppingItems { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuthConfig());
        modelBuilder.ApplyConfiguration(new UserConfig());
        modelBuilder.ApplyConfiguration(new ProductConfig());
        modelBuilder.ApplyConfiguration(new CategoryConfig());
        modelBuilder.ApplyConfiguration(new CustomerConfig());
        modelBuilder.ApplyConfiguration(new OrderConfig());
        modelBuilder.ApplyConfiguration(new OrderItemConfig());
        modelBuilder.ApplyConfiguration(new ProviderConfig());
        modelBuilder.ApplyConfiguration(new ShoppingConfig());
        modelBuilder.ApplyConfiguration(new ShoppingItemConfig());
        modelBuilder.ApplyConfiguration(new CashDrawerConfig());

        base.OnModelCreating(modelBuilder);
    }
}
