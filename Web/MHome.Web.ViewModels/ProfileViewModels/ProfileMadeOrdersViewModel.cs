using MHome.Data.Models;
using MHome.Services.Mapping;

namespace MHome.Web.ViewModels.ProfileViewModels
{
    public class ProfileMadeOrdersViewModel : IMapFrom<Order>
    {
        public string TimeOfOrder { get; set; }

        public decimal TotalPrice { get; set; }

        public string DeliveryType { get; set; }
    }
}
