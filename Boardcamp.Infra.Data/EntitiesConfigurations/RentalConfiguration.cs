using Boardcamp.Domain.Rentals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boardcamp.Infra.Data.EntitiesConfigurations
{
    public sealed class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("rentals");
            builder.HasKey(x => x.Id).HasName("PRIMARY");

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.CustomerId)
                .IsRequired()
                .HasColumnName("customer_id");

            builder.Property(x => x.GameId)
                .IsRequired()
                .HasColumnName("game_id");

            builder.Property(x => x.RentDate)
                .IsRequired()
                .HasColumnName("rent_date");

            builder.Property(x => x.DaysRented)
                .IsRequired()
                .HasColumnName("days_rented");

            builder.Property(x => x.OriginalPrice)
                .HasPrecision(5, 2)
                .IsRequired()
                .HasColumnName("original_price");

            builder.Property(x => x.DelayFee)
                .HasPrecision(5,2)
                .HasColumnName("delay_fee");

            builder.Property(x => x.ReturnDate)
                .HasColumnName("return_data");

            builder.HasOne(x => x.Game)
                .WithMany(x => x.Rentals)
                .HasConstraintName("fk_rentals_I")
                .HasForeignKey(x => x.GameId);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Rentals)
                .HasConstraintName("fk_rentals_II")
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
