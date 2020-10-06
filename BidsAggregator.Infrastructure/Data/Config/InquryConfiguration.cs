using BidsAggregator.Core;
using BidsAggregator.Core.Entities.Inquiry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BidsAggregator.Infrastructure.Data.Config
{
    internal sealed class InquryConfiguration : IEntityTypeConfiguration<Inquiry>
    {
        public void Configure(EntityTypeBuilder<Inquiry> builder)
        {
            builder
                .Property(inquiry => inquiry.Status)              
                .HasDefaultValue(InquiryStatus.Created)
                .IsRequired();

            builder
                .Property(inquiry => inquiry.CreatedDate)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder
                .Property(inquiry => inquiry.ModifiedDate)            
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder
                .Metadata
                .FindNavigation(nameof(Inquiry.Tasks))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .HasMany(inquiry => inquiry.Tasks)
                .WithOne()
                .HasForeignKey("InquiryId")
                .IsRequired();

            builder.HasIndex(inquiry => inquiry.Status);
            builder.HasIndex(inquiry => inquiry.CreatedDate);
            builder.HasIndex(inquiry => inquiry.ModifiedDate);
        }
    }
}
