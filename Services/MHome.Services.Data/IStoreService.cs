using MHome.Data.Models;
using System.Linq;

namespace MHome.Services.Data
{
    public interface IStoreService
    {
        IQueryable<Store> GetAll();
    }
}
