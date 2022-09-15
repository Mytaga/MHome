using MHome.Data.Models;
using MHome.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHome.Web.ViewModels.ProfileViewModels
{
    public class ListProfileViewModel : IMapFrom<Client>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
