using AutoMapper;
using BidsAggregator.Core.Entities.TempolaryInquiry;
using BidsAggregator.Web.Models.TempolaryInquiry;

namespace BidsAggregator.Web.AutoMapperProfiles
{
    public class TempolaryInquiryProfile : Profile
    {
        public TempolaryInquiryProfile()
        {
            CreateMap<CreateInquiryModel, TempolaryInquirer>();
        }
    }
}
