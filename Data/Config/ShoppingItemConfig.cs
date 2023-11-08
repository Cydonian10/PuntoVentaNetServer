using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiStore.Data
{
    public class ShoppingItemConfig : IEntityTypeConfiguration<ShoppingItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingItem> item)
        {
            item.ToTable("ShoppingItems");
            item.HasKey(i => i.Id);
            item.Property(i => i.Quantity).HasColumnType("decimal(4,2)");
            item.Property(i => i.UnitMeasurement).HasMaxLength(50).HasConversion(
                    v => v.ToString(), v => (UnitMeasurement)Enum.Parse(typeof(UnitMeasurement), v));
            item.Property(i => i.ProductId);
            item.Property(i => i.ShoppingId);


            item.HasOne(i => i.Product).WithMany(p => p.ShoppingItems).HasForeignKey(i => i.ProductId);
            item.HasOne(i => i.Shopping).WithMany(p => p.ShoppingItems).HasForeignKey(i => i.ShoppingId);

        }
    }
}
