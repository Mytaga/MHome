using MHome.Data.Models;
using MHome.Services.Mapping;

namespace MHome.Web.ViewModels.ProfileViewModels
{
    public class EditProfileViewModel : IMapFrom<Client>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string ImageUrl { get; set; }
    }
}
