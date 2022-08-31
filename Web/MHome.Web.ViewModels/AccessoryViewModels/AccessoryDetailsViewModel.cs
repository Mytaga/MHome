using MHome.Data.Models;
using MHome.Services.Mapping;

namespace MHome.Web.ViewModels.AccessoryViewModels
{
    public class AccessoryDetailsViewModel : IMapFrom<Accessory>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        public int StockQuantity { get; set; }
    }
}
