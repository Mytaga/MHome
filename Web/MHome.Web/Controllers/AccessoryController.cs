using MHome.Data.Models;
using MHome.Services.Data;
using MHome.Services.Mapping;
using MHome.Web.ViewModels.AccesoryViewModels;
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

        [HttpGet]
        public IActionResult All(string search)
        {
            IQueryable<Accessory> allAccessories = this.accessoryService.GetAllByName(search);

            AllAccessoriesViewModel viewModel = new AllAccessoriesViewModel()
            {
                AllAccessories = allAccessories.To<ListAllAccessoriesViewModel>().ToArray(),
                SearchQuery = search,
            };

            return this.View(viewModel);
        }
    }
}
