using BidsAggregator.Core;
using BidsAggregator.Core.Entities.TempolaryInquiry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BidsAggregator.Infrastructure.Data.Config
{
    internal sealed class TempolaryInquiryConfiguration : IEntityTypeConfiguration<TempolaryInquiry>
    {
        public void Configure(EntityTypeBuilder<TempolaryInquiry> builder)
        {
            builder
                .Property(inquiry => inquiry.TempolaryUrl)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(inquiry => inquiry.Body)
                .HasMaxLength(500)
                .IsRequired();

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
          

            builder.HasIndex(inquiry => inquiry.Status);
            builder.HasIndex(inquiry => inquiry.CreatedDate);
            builder.HasIndex(inquiry => inquiry.ModifiedDate);
        }
    }
}
