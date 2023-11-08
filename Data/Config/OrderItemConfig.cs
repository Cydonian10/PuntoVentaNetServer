using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiStore.Data
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> item)
        {
            item.ToTable("OrderItems");
            item.HasKey(i => i.Id);
            item.Property(i => i.Quantity).HasColumnType("decimal(4, 2)");
            item.Property(i => i.UnitPrice).HasColumnType("decimal(4, 2)");
            item.Property(i => i.UnitMeasurement).HasMaxLength(50).HasConversion(
                    v => v.ToString(), v => (UnitMeasurement)Enum.Parse(typeof(UnitMeasurement), v));

            item.Property(i => i.ProductId);
            item.Property(i => i.OrderId);

            item.HasOne(i => i.Order).WithMany(oi => oi.Items).HasForeignKey(i => i.OrderId);
            item.HasOne(i => i.Product).WithMany(oi => oi.Items).HasForeignKey(i => i.ProductId);
        }
    }
}
