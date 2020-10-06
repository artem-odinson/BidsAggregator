using BidsAggregator.Core.Interfaces;
using BidsAggregator.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BidsAggregator.Web.Extentions
{
    public static class DomainServiceCollectionExtensions
    {
        public static void AddBidsAggregatorDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IRepository<>), typeof(RepositoryBase<>));

            serviceCollection.AddTransient<IInquiryUnitOfWork, InquiryUnitOfWork>();
            serviceCollection.AddTransient<ITempolaryInquiryUnitOfWork, TempolaryInquiryUnitOfWork>();
        }

    }
}
