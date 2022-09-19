using MHome.Data.Models;
using MHome.Services.Data;
using MHome.Services.Mapping;
using MHome.Web.ViewModels.FurnitureViewModels;
using MHome.Web.ViewModels.ProfileViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MHome.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IClientService clientService;
        private readonly IUserService userService;
        private readonly IAddressService addressService;

        public ProfileController(IClientService clientService, IUserService userService, IAddressService addressService)
        {
            this.clientService = clientService;
            this.userService = userService;
            this.addressService = addressService;
        }

        public IActionResult Main()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = this.userService.GetById(userId);

            var clientProfile = user.Client;

            ListProfileViewModel viewModel = AutoMapperConfig.MapperInstance.Map<ListProfileViewModel>(clientProfile);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var profile = this.clientService.GetById(id);

            if (profile == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditProfileViewModel viewModel = AutoMapperConfig.MapperInstance.Map<EditProfileViewModel>(profile);

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(string id, EditProfileInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Edit", "Furniture");
            }

            Client client = this.clientService.GetById(id);

            Address address = new Address()
            {
                AddressText = model.Address,
                TownName = model.Town,
            };

            address.Clients.Add(client);

            this.addressService.AddAddress(address);

            client.FirstName = model.FirstName;
            client.LastName = model.LastName;
            client.PhoneNumber = model.PhoneNumber;
            client.ImageUrl = model.ImageURL;
            client.Address = address;

            this.clientService.EditClient(client);

            return this.RedirectToAction("Main", "Profile");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var clientProfile = await this.clientService.GetByIdАsync(id);

            if (clientProfile == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            DetailsProfileViewModel viewModel = AutoMapperConfig.MapperInstance.Map<DetailsProfileViewModel>(clientProfile);

            return this.View(viewModel);
        }
    }
}
