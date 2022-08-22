﻿using MHome.Data.Models;
using MHome.Services.Mapping;

namespace MHome.Web.ViewModels.FurnitureViewModels
{
    public class ListAllFurnitureViewModel : IMapFrom<Furniture>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Dimensions { get; set; }

        public int StockQuantity { get; set; }
    }
}