using BidsAggregator.Core.Entities.Inquiry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BidsAggregator.Infrastructure.Data.Config
{
    internal sealed class InquiryItemConfiguration : IEntityTypeConfiguration<InquiryItem>
    {
        public void Configure(EntityTypeBuilder<InquiryItem> builder)
        {
            builder
               .Property(task => task.Body)
               .HasMaxLength(1000)
               .IsRequired();

            builder
                .Property(task => task.IsComleted)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
