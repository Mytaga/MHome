using MHome.Data.Models;
using MHome.Data.Models.Enums;
using MHome.Services.Mapping;
using System;

namespace MHome.Web.ViewModels.OrderViewModels
{
    public class CreateOrderInputViewModel : IMapTo<Order>
    {
        public string ClientId { get; set; }

        public int Quantity { get; set; }

        public DateTime TimeOfOrder => DateTime.Now;

        public decimal TotalPrice { get; set; }

        public DeliveryType DeliveryType { get; set; }
    }
}
