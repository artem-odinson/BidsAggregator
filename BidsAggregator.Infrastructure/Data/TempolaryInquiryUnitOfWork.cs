using BidsAggregator.Core.Entities.TempolaryInquiry;
using BidsAggregator.Core.Interfaces;

namespace BidsAggregator.Infrastructure.Data
{
    public sealed class TempolaryInquiryUnitOfWork : ITempolaryInquiryUnitOfWork
    {
        private readonly BidsAggregatorContext _context;

        public IRepository<TempolaryInquiry> Inquiries { get; }

        public IRepository<TempolaryInquirer> Inquirers { get; }

        public TempolaryInquiryUnitOfWork(BidsAggregatorContext context)
        {
            _context = context;
            Inquiries = new RepositoryBase<TempolaryInquiry>(context);
            Inquirers = new RepositoryBase<TempolaryInquirer>(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
