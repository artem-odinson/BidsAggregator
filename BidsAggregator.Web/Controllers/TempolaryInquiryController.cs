using AutoMapper;
using BidsAggregator.Core.Entities.TempolaryInquiry;
using BidsAggregator.Core.Interfaces;
using BidsAggregator.Web.Models.TempolaryInquiry;
using Microsoft.AspNetCore.Mvc;

namespace BidsAggregator.Web.Controllers
{
    public class TempolaryInquiryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITempolaryInquiryUnitOfWork _unitOfWork;

        public TempolaryInquiryController(IMapper mapper, ITempolaryInquiryUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index() 
            => View(new CreateInquiryModel());

        [HttpPost]
        public IActionResult CreateInquiry([FromForm]CreateInquiryModel model)
        {
            if(ModelState.IsValid)
            {
                var inquirer = _mapper.Map<TempolaryInquirer>(model);
                var inquiry =  inquirer.CreateInquiry(model.InquiryBody);
                _unitOfWork.Inquirers.Add(inquirer);
                _unitOfWork.Save();
                
                inquiry.TempolaryUrl = Url.Action(nameof(InquiryDetail), new { inquiry.Id });
                _unitOfWork.Inquiries.Update(inquiry);
                _unitOfWork.Save();
                return RedirectToAction(nameof(InquiryDetail), new {  inquiry.Id });
            }

            return View(nameof(Index), model);
        }

        [HttpGet]
        public IActionResult InquiryDetail([FromRoute]long id)
        {
            var inquiry = _unitOfWork.Inquiries.GetEntry(id);
            return View(inquiry);
        }
    }
}
