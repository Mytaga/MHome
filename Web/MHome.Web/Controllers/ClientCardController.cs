using MHome.Data.Models;
using MHome.Services.Data;
using MHome.Services.Mapping;
using MHome.Web.ViewModels.ClientCardViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MHome.Web.Controllers
{
    public class ClientCardController : Controller
    {

        private readonly IUserService userService;
        private readonly IClientService clientService;
        private readonly IClientCardService clientCardService;

        public ClientCardController(IUserService userService, IClientService clientService, IClientCardService clientCardService)
        {
            this.userService = userService;
            this.clientService = clientService;
            this.clientCardService = clientCardService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientCardInputModel inputModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = this.userService.GetById(userId);

            Client client = this.clientService.GetById(user.Client.Id);

            if (client.ClietnCard != null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            inputModel.ClientId = client.Id;
            ClientCard clientCard = AutoMapperConfig.MapperInstance.Map<ClientCard>(inputModel);

            client.ClietnCard = clientCard;
            await this.clientCardService.AddClientCard(clientCard);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
