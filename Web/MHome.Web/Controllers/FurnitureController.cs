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

        public FurnitureController(IFurnitureService furnitureService)
        {
            this.furnitureService = furnitureService;
        }

        [HttpGet]
        public IActionResult All(string search)
        {
            IQueryable<Furniture> allFurnitures = this.furnitureService.GetAllByName();
            ICollection<string> allCategories = this.furnitureService.GetAllFurnitureCategories();

            AllFurnitureViewModel viewModel = new AllFurnitureViewModel()
            {
                AllFurniture = allFurnitures.To<ListAllFurnitureViewModel>().ToArray(),
                Categories = allCategories,
            };

            return this.View(viewModel);
        }
    }
}
