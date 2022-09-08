using AutoMapper;
using MHome.Data.Models;
using MHome.Services.Mapping;

namespace MHome.Web.ViewModels.OrderViewModels
{
    public class DetailsOrderViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public string ClientName { get; set; }

        public string TimeOfOrder { get; set; }

        public decimal TotalPrice { get; set; }

        public string DeliveryType { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Order, DetailsOrderViewModel>()
                .ForMember(d => d.ClientName, mo => mo.MapFrom(s => s.Client.FirstName));
        }
    }
}
