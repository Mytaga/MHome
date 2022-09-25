using MHome.Common;
using MHome.Data.Models;
using MHome.Services.Data;
using MHome.Services.Mapping;
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
        private readonly IUserService userService;
        private readonly IClientService clientService;

        public OrderController(IOrderService orderService, IFurnitureService furnitureService, IAccessoryService accessoryService, IUserService userService, IClientService clientService)
        {
            this.orderService = orderService;
            this.furnitureService = furnitureService;
            this.accessoryService = accessoryService;
            this.userService = userService;
            this.clientService = clientService;
        }

        [HttpGet]
        public IActionResult All(string search)
        {
            IQueryable<Order> allOrders = this.orderService.GetAllByName(search);

            AllOrdersViewModel viewModel = new AllOrdersViewModel()
            {
                AllOrders = allOrders.To<ListAllOrdersViewModel>().OrderByDescending(o => o.TimeOfOrder).ToArray(),
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.ApplicationUserId = userId;
            var user = this.userService.GetById(userId);

            Client client = this.clientService.GetById(user.Client.Id);

            Order order = null;

            if (this.furnitureService.ExistById(id))
            {
                var product = await this.furnitureService.GetByIdАsync(id);

                if (model.Quantity <= product.StockQuantity)
                {
                    if (client.ClietnCard != null)
                    {
                        model.TotalPrice = product.Price * 0.9M * model.Quantity;
                    }
                    else
                    {
                        model.TotalPrice = product.Price * model.Quantity;
                    }

                    product.StockQuantity -= model.Quantity;
                    order = AutoMapperConfig.MapperInstance.Map<Order>(model);
                    order.OrderedFurniture.Add(product);
                    client.BoughtFurniture.Add(product);
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
                    if (client.ClietnCard != null)
                    {
                        model.TotalPrice = product.Price * 0.9M * model.Quantity;
                    }
                    else
                    {
                        model.TotalPrice = product.Price * model.Quantity;
                    }

                    product.StockQuantity -= model.Quantity;
                    order = AutoMapperConfig.MapperInstance.Map<Order>(model);
                    order.OrderedAccesorries.Add(product);
                    client.BoughtAccessories.Add(product);
                }
                else
                {
                    return this.RedirectToAction("Error", "Home");
                }
            }

            order.User = user;
            user.Orders.Add(order);

            client.Orders.Add(order);

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

            viewModel.ClientName = order.User.FirstName + " " + order.User.LastName;

            return this.View(viewModel);
        }
    }
}
