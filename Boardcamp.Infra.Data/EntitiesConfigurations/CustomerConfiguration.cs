using Boardcamp.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boardcamp.Infra.Data.EntitiesConfigurations
{
    public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");
            builder.HasKey(x => x.Id).HasName("pk_customers");

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(x => x.Phone)
                .HasMaxLength(11)
                .IsRequired()
                .HasColumnName("phone");

            builder.Property(x => x.Cpf)
                .HasMaxLength(11)
                .IsRequired()
                .HasColumnName("cpf");

            builder.Property(x => x.Birthday)
                .IsRequired()
                .HasColumnName("birthday");
        }
    }
}
