using MHome.Common;
using MHome.Data.Models;
using MHome.Services.Data;
using MHome.Services.Mapping;
using MHome.Web.ViewModels.FurnitureViewModels;
using MHome.Web.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IClientService clientService;

        public OrderController(IOrderService orderService, IFurnitureService furnitureService, IAccessoryService accessoryService, IClientService clientService)
        {
            this.orderService = orderService;
            this.furnitureService = furnitureService;
            this.accessoryService = accessoryService;
            this.clientService = clientService;
        }

        [HttpGet]
        public IActionResult All(string search)
        {
            IQueryable<Order> allOrders = this.orderService.GetAllByName(search);

            AllOrdersViewModel viewModel = new AllOrdersViewModel()
            {
                AllOrders = allOrders.To<ListAllOrdersViewModel>().OrderBy(o => o.TimeOfOrder).ToArray(),
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
            model.ApplicationUserId = clientId;

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
            var client = this.clientService.GetById(clientId);
            order.Client = client;

            await this.orderService.AddOrder(order);

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Delete(string id)
        {
            var order = this.orderService.GetById(id);

            if (order == null)
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
            var order = this.orderService.GetById(id);

            if (order == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            this.orderService.DeleteOrder(order);
            return this.RedirectToAction("All", "Order");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var order = await this.orderService.GetByIdАsync(id);

            if (order == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            DetailsOrderViewModel viewModel = AutoMapperConfig.MapperInstance.Map<DetailsOrderViewModel>(order);

            viewModel.ClientName = order.Client.FirstName + " " + order.Client.LastName;

            return this.View(viewModel);
        }

    }
}
