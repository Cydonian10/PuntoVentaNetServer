using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiStore.Data
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.ToTable("Users");
            user.HasKey(p => p.Id);
            user.Property(p => p.Email).IsRequired(true).HasMaxLength(120);
            user.Property(p => p.Name).IsRequired(true);
            user.Property(p => p.Avatar).IsRequired(false);
            user.Property(p => p.Phone).IsRequired(false);


            user.HasOne(p => p.Role).WithMany( r => r.Users).HasForeignKey(p => p.RoleId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
