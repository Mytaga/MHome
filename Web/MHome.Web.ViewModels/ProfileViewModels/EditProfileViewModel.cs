using MHome.Data.Models;
using MHome.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHome.Web.ViewModels.ProfileViewModels
{
    public class EditProfileViewModel : IMapFrom<Client>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
