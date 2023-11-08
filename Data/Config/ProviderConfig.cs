using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiStore.Data
{
    public class ProviderConfig : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> provider)
        {
            provider.ToTable("Providers");
            provider.HasKey(p => p.Id);
            provider.Property(p => p.Name);
            provider.Property(p => p.Address);
            provider.Property(p => p.City);
            provider.Property(p => p.Phone);

            provider.HasMany(p => p.Products).WithMany(p => p.Providers).UsingEntity(j => j.ToTable("ProviderProducto"));


        }
    }
}
