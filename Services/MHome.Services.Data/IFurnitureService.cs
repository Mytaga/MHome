using MHome.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public interface IFurnitureService
    {
        IQueryable<Furniture> GetAllByName(string searchName = "");

        IQueryable<Furniture> GetAllByCategory(string categoryName = "");

        ICollection<string> GetAllFurnitureCategories();

        Task<Furniture> GetByIdАsync(string id);

        Furniture GetById(string id);

        Task AddFurniture(Furniture furniture);

        void DeleteFurniture(Furniture furniture);
    }
}