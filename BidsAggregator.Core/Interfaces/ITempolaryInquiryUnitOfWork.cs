using BidsAggregator.Core.Entities.TempolaryInquiry;

namespace BidsAggregator.Core.Interfaces
{
    public interface ITempolaryInquiryUnitOfWork
    {
        IRepository<TempolaryInquiry> Inquiries { get; }
        IRepository<TempolaryInquirer> Inquirers { get; }

        void Save();
    }
}
