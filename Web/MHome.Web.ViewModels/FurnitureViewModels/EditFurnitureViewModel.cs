using AutoMapper;
using MHome.Data.Models;
using MHome.Services.Mapping;
using System.Collections.Generic;

namespace MHome.Web.ViewModels.FurnitureViewModels
{
    public class EditFurnitureViewModel : IMapFrom<Furniture>, IHaveCustomMappings
    {
        public EditFurnitureViewModel()
        {
            this.Categories = new List<ListCategoriesOnFurnitureViewModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Dimensions { get; set; }

        public int StockQuantity { get; set; }

        public ICollection<ListCategoriesOnFurnitureViewModel> Categories { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Category, ListCategoriesOnFurnitureViewModel>()
                .ForMember(d => d.Id, mo => mo.MapFrom(s => s.Id))
                .ForMember(d => d.Name, mo => mo.MapFrom(s => s.Name));
        }
    }
}
