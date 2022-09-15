using MHome.Services.Data;
using Microsoft.AspNetCore.Mvc;

namespace MHome.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IClientService clientService;

        public ProfileController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public IActionResult Create()
        {
            return this.View();
        }
    }
}
