using MHome.Services.Data;
using MHome.Services.Mapping;
using MHome.Web.ViewModels.StoreViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MHome.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService storeService;

        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var allStores = this.storeService.GetAll();

            AllStoresViewModel viewModel = new AllStoresViewModel()
            {
                AllStores = allStores.To<ListAllStoresViewModel>().ToArray(),
            };

            return this.View(viewModel);
        }
    }
}
