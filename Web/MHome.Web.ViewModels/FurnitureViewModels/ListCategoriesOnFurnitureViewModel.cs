using MHome.Data.Models;
using MHome.Services.Mapping;

namespace MHome.Web.ViewModels.FurnitureViewModels
{
    public class ListCategoriesOnFurnitureViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
