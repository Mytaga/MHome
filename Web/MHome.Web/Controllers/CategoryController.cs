using MHome.Common;
using MHome.Data.Models;
using MHome.Services.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MHome.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]

        public async Task<IActionResult> Create(Category category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Category");
            }

            if (this.categoryService.ExistById(category.Id))
            {
                return this.RedirectToAction("Create", "Category");
            }

            await this.categoryService.AddCategory(category);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
