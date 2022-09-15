using MHome.Services.Data;
using MHome.Services.Mapping;
using MHome.Web.ViewModels.ProfileViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MHome.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IClientService clientService;
        private readonly IUserService userService;

        public ProfileController(IClientService clientService, IUserService userService)
        {
            this.clientService = clientService;
            this.userService = userService;
        }

        public IActionResult Main()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = this.userService.GetById(userId);

            var clientProfile = user.Client;

            ListProfileViewModel viewModel = AutoMapperConfig.MapperInstance.Map<ListProfileViewModel>(clientProfile);

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }
    }
}
