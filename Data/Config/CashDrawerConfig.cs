using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiStore.Data;

public class CashDrawerConfig : IEntityTypeConfiguration<CashDrawer>
{
    public void Configure(EntityTypeBuilder<CashDrawer> cash)
    {
        cash.ToTable("CashDrawers");
        cash.HasKey(c => c.Id);
        cash.Property(c => c.StartTime).HasColumnType("time");
        cash.Property(c => c.EndTime).HasColumnType("time");
        cash.Property(c => c.InitSale).HasColumnType("decimal(4, 2)");
        cash.Property(c => c.TotalSale).HasColumnType("decimal(4, 2)");
        cash.Property(c => c.Open);
    }
}
