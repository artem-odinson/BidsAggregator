using Microsoft.AspNetCore.Mvc;

namespace BidsAggregator.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public ViewResult About() => View();

        public ViewResult Error()
        {
            return View();
        }
    }
}