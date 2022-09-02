using MHome.Common;
using MHome.Data.Models;
using MHome.Services.Data;
using MHome.Services.Mapping;
using MHome.Web.ViewModels.AccessoryViewModels;
using MHome.Web.ViewModels.FurnitureViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(CreateAccessoryInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Accessory");
            }

            Accessory accessory = AutoMapperConfig.MapperInstance.Map<Accessory>(inputModel);

            await this.accessoryService.AddAccessory(accessory);

            return this.RedirectToAction("All", "Accessory");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var accessory = await this.accessoryService.GetByIdАsync(id);

            if (accessory == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            AccessoryDetailsViewModel viewModel = AutoMapperConfig.MapperInstance.Map<AccessoryDetailsViewModel>(accessory);

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Delete(string id)
        {
            var accessory = this.accessoryService.GetById(id);

            if (accessory == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            return this.View();
        }

        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult DeleteConfirmed(string id)
        {
            var accessory = this.accessoryService.GetById(id);

            if (accessory == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            this.accessoryService.DeleteAccesory(accessory);
            return this.RedirectToAction("All", "Accessory");
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(string id)
        {
            var accessory = this.accessoryService.GetById(id);

            if (accessory == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditAccessoryViewModel viewModel =
                AutoMapperConfig.MapperInstance.Map<EditAccessoryViewModel>(accessory);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(string id, EditAccessoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Edit", "Furniture");
            }

            Accessory accessory = this.accessoryService.GetById(id);

            accessory.Name = model.Name;
            accessory.Description = model.Description;
            accessory.Price = model.Price;
            accessory.ImageURL = model.ImageURL;
            accessory.StockQuantity = model.StockQuantity;

            this.accessoryService.EditAccessory(accessory);

            return this.RedirectToAction("All", "Accessory");
        }
    }
}
