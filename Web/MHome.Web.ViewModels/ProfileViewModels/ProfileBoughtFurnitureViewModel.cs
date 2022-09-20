using MHome.Data.Models;
using MHome.Services.Mapping;

namespace MHome.Web.ViewModels.ProfileViewModels
{
    public class ProfileBoughtFurnitureViewModel : IMapFrom<Furniture>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}
