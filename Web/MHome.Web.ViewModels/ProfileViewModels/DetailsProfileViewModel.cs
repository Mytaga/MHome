using AutoMapper;
using MHome.Data.Models;
using MHome.Services.Mapping;
using System.Collections.Generic;

namespace MHome.Web.ViewModels.ProfileViewModels
{
    public class DetailsProfileViewModel : IMapFrom<Client>, IHaveCustomMappings
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Town { get; set; }

        public string ImageUrl { get; set; }

        public string ClientCard { get; set; }

        public ICollection<ProfileBoughtFurnitureViewModel> BoughtFurniture { get; set; }

        public ICollection<ProfileBoughtAccessoryViewModel> BoughtAccessories { get; set; }

        public ICollection<ProfileMadeOrdersViewModel> Orders { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Client, DetailsProfileViewModel>()
                .ForMember(d => d.Address, mo => mo.MapFrom(s => s.Address.AddressText))
                .ForMember(d => d.Town, mo => mo.MapFrom(s => s.Address.TownName));
        }
    }
}
