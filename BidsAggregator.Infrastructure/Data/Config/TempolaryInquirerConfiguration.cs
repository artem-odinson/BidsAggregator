using BidsAggregator.Core.Entities.TempolaryInquiry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BidsAggregator.Infrastructure.Data.Config
{
    internal sealed class TempolaryInquirerConfiguration : IEntityTypeConfiguration<TempolaryInquirer>
    {
        public void Configure(EntityTypeBuilder<TempolaryInquirer> builder)
        {
            builder
                .Property(inquirer => inquirer.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(inquirer => inquirer.MiddleName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(inquirer => inquirer.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(inquirer => inquirer.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(inquirer => inquirer.Street)
                .HasMaxLength(70)
                .IsRequired();

            builder
               .Property(inquirer => inquirer.HouseNumber)
               .HasMaxLength(500)
               .IsRequired();

            builder
                .Metadata
                .FindNavigation(nameof(TempolaryInquirer.Inquiries))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .HasMany(inquirer => inquirer.Inquiries)
                .WithOne(bid => bid.Inquirer)                
                .IsRequired();

            builder.HasIndex(inquirer => new
            {
                inquirer.Id,
                inquirer.FirstName,
                inquirer.MiddleName,
                inquirer.LastName,
                inquirer.PhoneNumber,
                inquirer.Street,
                inquirer.HouseNumber
            });
        }
    }
}
