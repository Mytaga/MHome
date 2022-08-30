using MHome.Data.Models;
using MHome.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MHome.Web.Controllers
{
    public class AccessoryController : Controller
    {
        private readonly IAccessoryService accessoryService;

        public AccessoryController(IAccessoryService accessoryService)
        {
            this.accessoryService = accessoryService;
        }

        public IActionResult All(string search)
        {
            IQueryable<Accessory> allAccessories = this.accessoryService.GetAllByName(search);

            return this.View();
        }
    }
}
