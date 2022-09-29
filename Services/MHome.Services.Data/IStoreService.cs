using MHome.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public interface IStoreService
    {
        IQueryable<Store> GetAll();

        Task AddStore(Store store);
    }
}
