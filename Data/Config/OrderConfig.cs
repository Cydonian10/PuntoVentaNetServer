using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiStore.Data
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> order)
        {
            order.ToTable("Orders");
            order.HasKey(o => o.Id);
            order.Property(o => o.Pay);
            order.Property(o => o.TotalAmount).HasColumnType("decimal(4,2)");
            order.Property(o => o.OrderDate);

            order.HasOne(o => o.Customer).WithMany( c => c.Orders).HasForeignKey(p =>p.CustomerId).OnDelete(DeleteBehavior.NoAction);
            order.HasOne(o => o.User).WithMany( c => c.Orders).HasForeignKey(p =>p.UserId).OnDelete(DeleteBehavior.NoAction);

            
        }
    }
}
