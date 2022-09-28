using AutoMapper;
using MHome.Data.Models;
using MHome.Services.Mapping;

namespace MHome.Web.ViewModels.StoreViewModels
{
    public class ListAllStoresViewModel : IMapFrom<Store>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string TownName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Store, ListAllStoresViewModel>()
               .ForMember(d => d.Address, mo => mo.MapFrom(s => s.Address.AddressText))
               .ForMember(d => d.TownName, mo => mo.MapFrom(s => s.Address.TownName));
        }
    }
}
