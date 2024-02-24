using Boardcamp.Domain.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boardcamp.Infra.Data.EntitiesConfigurations
{
    public sealed class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("games");
            builder.HasKey(x => x.Id).HasName("pk_games");

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(x => x.Image)
                .HasMaxLength(300)
                .IsRequired()
                .HasColumnName("image");

            builder.Property(x => x.Stock)
                .IsRequired()
                .HasColumnName("stock");

            builder.Property(x => x.PricePerDay)
                .HasPrecision(3, 2)
                .IsRequired()
                .HasColumnName("price_per_day");
        }
    }
}
