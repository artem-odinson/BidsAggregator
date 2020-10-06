using BidsAggregator.Core.Entities.Inquiry;

namespace BidsAggregator.Core.Interfaces
{
    public interface IInquiryUnitOfWork
    {
        IRepository<Inquiry> Inquiries { get; }
        IRepository<Inquirer> Inquireres { get; }

        void Save();
    }
}
