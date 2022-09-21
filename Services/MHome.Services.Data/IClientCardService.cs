using MHome.Data.Models;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public interface IClientCardService
    {
        Task<ClientCard> GetByIdАsync(string id);

        ClientCard GetById(string id);

        Task AddClientCard(ClientCard clientCard);
    }
}
