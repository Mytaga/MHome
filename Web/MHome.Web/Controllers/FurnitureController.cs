using MHome.Data.Models;
using MHome.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> All(string search)
        {
            ICollection<Furniture> allFurnitures = await this.furnitureService.GetAllByName();

            return this.View(allFurnitures);
        }
    }
}
