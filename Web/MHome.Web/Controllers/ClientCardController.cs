using Microsoft.AspNetCore.Mvc;

namespace MHome.Web.Controllers
{
    public class ClientCardController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
