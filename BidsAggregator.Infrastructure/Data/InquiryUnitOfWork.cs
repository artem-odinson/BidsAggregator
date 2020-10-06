using BidsAggregator.Core.Entities.Inquiry;
using BidsAggregator.Core.Interfaces;

namespace BidsAggregator.Infrastructure.Data
{
    public sealed class InquiryUnitOfWork : IInquiryUnitOfWork
    {
        private readonly BidsAggregatorContext _context;

        public IRepository<Inquiry> Inquiries { get; }

        public IRepository<Inquirer> Inquireres { get; }

        public InquiryUnitOfWork(BidsAggregatorContext context)
        {
            _context = context;
            Inquiries = new RepositoryBase<Inquiry>(_context);
            Inquireres = new RepositoryBase<Inquirer>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
