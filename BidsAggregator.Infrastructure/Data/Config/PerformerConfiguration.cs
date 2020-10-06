using BidsAggregator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BidsAggregator.Infrastructure.Data.Config
{
    internal sealed class PerformerConfiguration : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> builder)
        {
            builder
                .Property(perfomer => perfomer.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(perfomer => perfomer.MiddleName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(perfomer => perfomer.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(perfomer => perfomer.PhoneNumber)
                .HasMaxLength(11)
                .IsRequired();

            builder
                .Property(perfomer => perfomer.PositiveRating)
                .HasMaxLength(1000)
                .HasDefaultValue(0);

            builder
               .Property(perfomer => perfomer.NegativeRating)
               .HasMaxLength(1000)
               .HasDefaultValue(0);

            builder
                .Metadata
                .FindNavigation(nameof(Performer.Bids))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .HasMany(performer => performer.Bids)
                .WithOne(bid => bid.Performer)
                .HasForeignKey("PerformerId")
                .IsRequired(false);
           
            builder.HasIndex(performer => new { performer.Id, performer.FirstName, performer.MiddleName, performer.LastName });
        }
    }
}
