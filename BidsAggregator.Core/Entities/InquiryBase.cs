using System;

namespace BidsAggregator.Core.Entities
{
    public abstract class InquiryBase : EntityBase
    {
        public DateTime CreatedDate { get; } = DateTime.Now;
        public DateTime ModifiedDate { get; protected set; } = DateTime.Now;
        public InquiryStatus Status { get; protected set; } = InquiryStatus.Created;

        public long? PerformerId { get; set; }
        public Performer Performer { get; set; }

        protected InquiryBase() { }

        protected InquiryBase(long id, DateTime createdDate,
            DateTime modifiedDate, InquiryStatus status) : base(id)
        {
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Status = status;
        }

        public void BindPerformer(long performerId)
        {
            if (Status == InquiryStatus.Created && PerformerId == null)
            {
                PerformerId = performerId;
                Status = InquiryStatus.Proccessing;
                ModifiedDate = DateTime.Now;
            }
        }

        public void UnbindPerformer()
        {
            if (Status == InquiryStatus.Proccessing && PerformerId != null)
            {
                PerformerId = null;
                Status = InquiryStatus.Created;
                ModifiedDate = DateTime.Now;
            }
        }
    }
}
