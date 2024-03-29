﻿using AutoMapper;
using MHome.Data.Models;
using MHome.Data.Models.Enums;
using MHome.Services.Mapping;
using System;

namespace MHome.Web.ViewModels.OrderViewModels
{
    public class ListAllOrdersViewModel : IMapFrom<Order>
    {
        public string Id { get; set; }

        public string ClientName { get; set; }

        public DateTime TimeOfOrder { get; set; }

        public decimal TotalPrice { get; set; }

        public DeliveryType DeliveryType { get; set; }
    }
}
