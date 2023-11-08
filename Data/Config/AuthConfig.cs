using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiStore.Data
{
    public class AuthConfig : IEntityTypeConfiguration<AuthUser>
    {
        public void Configure(EntityTypeBuilder<AuthUser> auth)
        {
            auth.ToTable("Auths");
            auth.HasKey(p => p.Id);
            auth.Property(p => p.Name).IsRequired();
            auth.Property(p => p.Password).IsRequired();
            auth.Property(p => p.Email).IsRequired().HasMaxLength(120);
        }
    }
}
