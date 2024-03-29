﻿using MHome.Common;
using MHome.Data.Models;
using MHome.Services.Data;
using MHome.Services.Mapping;
using MHome.Web.ViewModels.FurnitureViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Web.Controllers
{
    public class FurnitureController : BaseController
    {
        private readonly IFurnitureService furnitureService;
        private readonly ICategoryService categoryService;

        public FurnitureController(IFurnitureService furnitureService, ICategoryService categoryService)
        {
            this.furnitureService = furnitureService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult All(string search)
        {
            IQueryable<Furniture> allFurnitures = this.furnitureService.GetAllByName(search);
            ICollection<string> allCategories = this.furnitureService.GetAllFurnitureCategories();

            AllFurnitureViewModel viewModel = new AllFurnitureViewModel()
            {
                AllFurniture = allFurnitures.To<ListAllFurnitureViewModel>().ToArray(),
                Categories = allCategories,
                SearchQuery = search,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            ICollection<ListCategoriesOnFurnitureViewModel> allCategories =
                this.categoryService.All().To<ListCategoriesOnFurnitureViewModel>().ToArray();

            return this.View(allCategories);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(CreateFurnitureInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Furniture");
            }

            if (!this.categoryService.ExistById(model.CategoryId))
            {
                return this.RedirectToAction("Create", "Furniture");
            }

            Furniture furniture = AutoMapperConfig.MapperInstance.Map<Furniture>(model);

            await this.furnitureService.AddFurniture(furniture);

            return this.RedirectToAction("All", "Furniture");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var furniture = await this.furnitureService.GetByIdАsync(id);

            if (furniture == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            DetailsFurnitureViewModel viewModel = AutoMapperConfig.MapperInstance.Map<DetailsFurnitureViewModel>(furniture);

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Delete(string id)
        {
            var furniture = this.furnitureService.GetById(id);

            if (furniture == null)
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
            var furniture = this.furnitureService.GetById(id);

            if (furniture == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            this.furnitureService.DeleteFurniture(furniture);
            return this.RedirectToAction("All", "Furniture");
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(string id)
        {
            var furniture = this.furnitureService.GetById(id);

            if (furniture == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditFurnitureViewModel viewModel =
                AutoMapperConfig.MapperInstance.Map<EditFurnitureViewModel>(furniture);

            ICollection<ListCategoriesOnFurnitureViewModel> allCategories =
                this.categoryService.All().To<ListCategoriesOnFurnitureViewModel>().ToArray();

            viewModel.Categories = allCategories;

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(string id, EditFurnitureInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Edit", "Furniture");
            }

            if (!this.categoryService.ExistById(model.CategoryId))
            {
                return this.RedirectToAction("Edit", "Furniture");
            }

            Furniture furniture = this.furnitureService.GetById(id);
            Category category = this.categoryService.GetById(model.CategoryId);

            furniture.Name = model.Name;
            furniture.ImageURL = model.ImageURL;
            furniture.Description = model.Description;
            furniture.Price = model.Price;
            furniture.Dimensions = model.Dimensions;
            furniture.Category = category;
            furniture.StockQuantity = model.StockQuantity;

            this.furnitureService.EditFurniture(furniture);

            return this.RedirectToAction("All", "Furniture");
        }
    }
}