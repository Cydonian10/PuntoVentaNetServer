using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiStore.Data
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> customer)
        {
            customer.ToTable("Cutomers");
            customer.HasKey(c => c.Id);
            customer.Property(c => c.Name);
            customer.Property(c => c.LastName);
            customer.Property(c => c.Phone);           

        }
    }
}
