using MHome.Data.Models;
using MHome.Services.Mapping;

namespace MHome.Web.ViewModels.ProfileViewModels
{
    public class ProfileBoughtAccessoryViewModel : IMapFrom<Accessory>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
