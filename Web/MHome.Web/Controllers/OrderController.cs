using MHome.Data.Models;
using MHome.Services.Data;
using MHome.Services.Mapping;
using MHome.Web.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MHome.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IFurnitureService furnitureService;
        private readonly IAccessoryService accessoryService;

        public OrderController(IOrderService orderService, IFurnitureService furnitureService, IAccessoryService accessoryService)
        {
            this.orderService = orderService;
            this.furnitureService = furnitureService;
            this.accessoryService = accessoryService;
        }

        [HttpGet]
        public IActionResult All(string search)
        {
            IQueryable<Order> allOrders = this.orderService.GetAllByName(search);

            AllOrdersViewModel viewModel = new AllOrdersViewModel()
            {
                AllOrders = allOrders.To<ListAllOrdersViewModel>().ToArray(),
                SearchQuery = search,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(string id, CreateOrderInputViewModel model)
        {
            var clientId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.ClientId = clientId;

            if (this.furnitureService.ExistById(id))
            {
                var product = await this.furnitureService.GetByIdАsync(id);

                if (model.Quantity <= product.StockQuantity)
                {
                    model.TotalPrice = product.Price * model.Quantity;
                    product.StockQuantity -= model.Quantity;
                }
                else
                {
                    return this.RedirectToAction("Error", "Home");
                }
            }

            if (this.accessoryService.ExistById(id))
            {
                var product = await this.accessoryService.GetByIdАsync(id);
                if (model.Quantity <= product.StockQuantity)
                {
                    model.TotalPrice = product.Price * model.Quantity;
                    product.StockQuantity -= model.Quantity;
                }
                else
                {
                    return this.RedirectToAction("Error", "Home");
                }
            }

            Order order = AutoMapperConfig.MapperInstance.Map<Order>(model);

            await this.orderService.AddOrder(order);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
