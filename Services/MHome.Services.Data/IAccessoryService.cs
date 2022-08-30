using MHome.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public interface IAccessoryService
    {
        IQueryable<Accessory> GetAllByName(string searchName = "");

        Task<Accessory> GetByIdАsync(string id);

        Accessory GetById(string id);

        Task AddAccessory(Accessory accessory);

        void DeleteAccesory(Accessory accessory);

        Task EditAccessory(Accessory accessory);
    }
}
