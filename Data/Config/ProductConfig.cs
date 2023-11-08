using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiStore.Data
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> product)
        {
            product.ToTable("Products");
            product.HasKey(product => product.Id);
            product.Property(product => product.CategoryId);
            product.Property(product => product.Name).IsRequired(true).HasMaxLength(100);
            product.Property(product => product.Price).IsRequired().HasColumnType("decimal(4, 2)");
            product.Property(product => product.Stock).IsRequired().HasColumnType("decimal(10, 2)");
            product.Property(product => product.Description).IsRequired(false);
            product.Property(product => product.Image).IsRequired(false);
            product.Property(product => product.UnitMeasurement).HasMaxLength(50).HasConversion(
                    v => v.ToString(), v => (UnitMeasurement)Enum.Parse(typeof(UnitMeasurement), v));

            product.Property(product => product.Igv).IsRequired().HasColumnType("decimal(2,2)");
            product.Property(product => product.FechaCreacion).HasDefaultValueSql("GETDATE()");

            product.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
