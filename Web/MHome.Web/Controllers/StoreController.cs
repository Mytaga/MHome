using MHome.Data.Models;
using MHome.Services.Data;
using MHome.Services.Mapping;
using MHome.Web.ViewModels.StoreViewModel;
using MHome.Web.ViewModels.StoreViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService storeService;
        private readonly IAddressService addressService;

        public StoreController(IStoreService storeService, IAddressService addressService)
        {
            this.storeService = storeService;
            this.addressService = addressService;
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

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStoreInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Store");
            }

            Address address = new Address()
            {
                AddressText = model.Address,
                TownName = model.TownName,
            };

            Store store = new Store()
            {
                Name = model.Name,
                Description = model.Description,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = address,
            };

            await this.addressService.AddAddress(address);
            await this.storeService.AddStore(store);

            return this.RedirectToAction("All", "Store");
        }
    }
}
