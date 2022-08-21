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
        Task<ICollection<Furniture>> GetAllByName(string searchName = "");

        Task<ICollection<Furniture>> GetAllByCategory(string categoryName = "");

        Task<Furniture> GetById(string id);
    }
}
