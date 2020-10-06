
namespace BidsAggregator.Core.Entities.Inquiry
{
    public class InquiryItem : EntityBase
    {
        public string Body { get; set; }        
        public bool IsComleted { get; internal set; }

        internal InquiryItem() : base() { }

        protected InquiryItem(long id, bool isComleted) : base(id)
        {
            IsComleted = isComleted;
        }
    }
}
