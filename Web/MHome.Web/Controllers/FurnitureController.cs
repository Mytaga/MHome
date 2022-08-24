using MHome.Data.Models;
using MHome.Services.Data;
using MHome.Services.Mapping;
using MHome.Web.ViewModels.FurnitureViewModels;
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
        public IActionResult Create()
        {
            ICollection<ListCategoriesOnFurnitureViewModel> allCategories =
                this.categoryService.All().To<ListCategoriesOnFurnitureViewModel>().ToArray();

            return this.View(allCategories);
        }
    }
}