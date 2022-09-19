using AutoMapper;
using MHome.Data.Models;
using MHome.Services.Mapping;

namespace MHome.Web.ViewModels.ProfileViewModels
{
    public class ListProfileViewModel : IMapFrom<Client>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Town { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Client, ListProfileViewModel>()
                .ForMember(d => d.Address, mo => mo.MapFrom(s => s.Address.AddressText))
                .ForMember(d => d.Town, mo => mo.MapFrom(s => s.Address.TownName));
        }
    }
}
