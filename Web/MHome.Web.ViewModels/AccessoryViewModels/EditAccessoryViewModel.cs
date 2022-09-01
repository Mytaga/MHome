using MHome.Data.Models;
using MHome.Data.Models.Common;
using MHome.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace MHome.Web.ViewModels.AccessoryViewModels
{
    public class EditAccessoryViewModel : IMapFrom<Accessory>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        public int StockQuantity { get; set; }
    }
}
