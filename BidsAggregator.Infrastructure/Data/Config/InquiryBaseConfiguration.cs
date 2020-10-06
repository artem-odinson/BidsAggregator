using BidsAggregator.Core.Entities;
using BidsAggregator.Core.Entities.Inquiry;
using BidsAggregator.Core.Entities.TempolaryInquiry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BidsAggregator.Infrastructure.Data.Config
{
    internal sealed class InquiryBaseConfiguration : IEntityTypeConfiguration<InquiryBase>
    {
        public void Configure(EntityTypeBuilder<InquiryBase> builder)
        {
            builder
                .ToTable("Inquiries")
                .HasDiscriminator<int>("InquiryType")
                .HasValue<Inquiry>(1)
                .HasValue<TempolaryInquiry>(2);
        }
    }
}
