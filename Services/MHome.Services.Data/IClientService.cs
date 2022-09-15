using MHome.Data.Models;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public interface IClientService
    {
        Task<Client> GetByIdАsync(string id);

        Client GetById(string id);
    }
}
