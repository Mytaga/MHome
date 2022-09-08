using MHome.Data.Models;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public interface IClientService
    {
        Task<ApplicationUser> GetByIdАsync(string id);

        ApplicationUser GetById(string id);
    }
}
