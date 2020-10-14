using System;

namespace BidsAggregator.Core.Entities.TempolaryInquiry
{
    public class TempolaryInquiry : InquiryBase, IAggregateRoot
    {
        public string TempolaryUrl { get; set; }
        public string Body { get; private set; }

        public long InquirerId { get; set; }
        public TempolaryInquirer Inquirer { get; set; }

        internal TempolaryInquiry(string body) : base()
        {
            Body = body;
        }

        protected TempolaryInquiry(long id, string tempolaryUrl, DateTime createdDate, DateTime modifiedDate, InquiryStatus status, string body) 
            : base(id, createdDate, modifiedDate, status)
        {
            TempolaryUrl = tempolaryUrl;
            Body = body;
        }

        public void EditBody(string body)
        {
            if (string.IsNullOrWhiteSpace(body))
                throw new ArgumentNullException(nameof(body));

            if (Status != InquiryStatus.Created)
                return;

            Body = body;
            ModifiedDate = DateTime.Now;
        }

        public void Complete()
        {
            if(Status == InquiryStatus.Proccessing)
            {
                Status = InquiryStatus.Completed;
                ModifiedDate = DateTime.Now;
            }
        }
    }
}
