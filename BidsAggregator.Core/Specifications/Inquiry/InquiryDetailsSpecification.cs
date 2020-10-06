using InquiryEntities = BidsAggregator.Core.Entities.Inquiry;

namespace BidsAggregator.Core.Specifications.Inquiry
{
    public sealed class InquiryDetailsSpecification : SpecificationBase<InquiryEntities.Inquiry>
    {
        public InquiryDetailsSpecification(long entiyId) 
            : base(b => b.Id == entiyId)
        {
            AddInclude(b => b.Performer);
            AddInclude(b => b.Inquirer);
            AddInclude(b => b.Tasks);
        }
    }
}
