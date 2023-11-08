using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiStore.Data
{
    public class ShoppingConfig : IEntityTypeConfiguration<Shopping>
    {
        public void Configure(EntityTypeBuilder<Shopping> shopping)
        {
            shopping.ToTable("Shopping");
            shopping.HasKey(s => s.Id);
            shopping.Property(s => s.ProviderId);
            shopping.Property(s => s.DatePurchase);
            shopping.Property(s => s.TotalAmount).HasColumnType("decimal(10, 2)");

            shopping.HasOne(s => s.Provider).WithMany( p => p.Shoppings).HasForeignKey(s => s.ProviderId);
        }
    }
}
