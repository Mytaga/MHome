using MHome.Data.Models;
using MHome.Services.Mapping;

namespace MHome.Web.ViewModels.AccessoryViewModels
{
    public class ListAllAccessoriesViewModel : IMapFrom<Accessory>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Dimensions { get; set; }

        public int StockQuantity { get; set; }
    }
}
