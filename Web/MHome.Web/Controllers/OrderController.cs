using MHome.Data.Models;
using MHome.Services.Data;
using MHome.Services.Mapping;
using MHome.Web.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MHome.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
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
    }
}
