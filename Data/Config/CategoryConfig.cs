using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiStore.Data
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category.ToTable("Categories");
            category.HasKey(c => c.Id);
            category.Property(c => c.Name).IsRequired().HasMaxLength(80);
            category.Property(c => c.Description).HasColumnType("text").IsRequired();
        }
    }
}
