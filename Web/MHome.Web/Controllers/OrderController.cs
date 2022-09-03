using Microsoft.AspNetCore.Mvc;

namespace MHome.Web.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
