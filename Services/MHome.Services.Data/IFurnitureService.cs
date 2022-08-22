using MHome.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public interface IFurnitureService
    {
        IQueryable<Furniture> GetAllByName(string searchName = "");

        IQueryable<Furniture> GetAllByCategory(string categoryName = "");

        ICollection<string> GetAllFurnitureCategories();

        Task<Furniture> GetById(string id);
    }
}
