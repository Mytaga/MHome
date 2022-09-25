using AutoMapper;
using MHome.Data.Models;
using MHome.Services.Mapping;

namespace MHome.Web.ViewModels.FurnitureViewModels
{
    public class DetailsFurnitureViewModel : IMapFrom<Furniture>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal PriceWithDiscount => this.Price * 0.90M;

        public string ImageURL { get; set; }

        public string Dimensions { get; set; }

        public string CategoryName { get; set; }

        public int StockQuantity { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Furniture, DetailsFurnitureViewModel>()
                .ForMember(d => d.CategoryName, mo => mo.MapFrom(s => s.Category.Name));
        }
    }
}
