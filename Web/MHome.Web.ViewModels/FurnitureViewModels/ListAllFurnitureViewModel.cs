using MHome.Data.Models;
using MHome.Services.Mapping;

namespace MHome.Web.ViewModels.FurnitureViewModels
{
    public class ListAllFurnitureViewModel : IMapFrom<Furniture>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal PriceWithDiscount => this.Price * 0.90M;

        public string Dimensions { get; set; }

        public int StockQuantity { get; set; }

        public string CategoryName { get; set; }
    }
}