using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public class FurnitureService : IFurnitureService
    {
        private const string EmptyString = "";
        private readonly IDeletableEntityRepository<Furniture> furnitureRepo;

        public FurnitureService(IDeletableEntityRepository<Furniture> furnitureRepo)
        {
            this.furnitureRepo = furnitureRepo;
        }

        public async Task<ICollection<Furniture>> GetAllByName(string searchName = EmptyString)
        {
            if (searchName != EmptyString)
            {
                return await this.furnitureRepo
                    .AllAsNoTracking()
                    .Where(f => f.Name.ToLower().Contains(searchName.ToLower()))
                    .ToArrayAsync();
            }

            return await this.furnitureRepo.All().ToArrayAsync();
        }

        public async Task<ICollection<Furniture>> GetAllByCategory(string categoryName = EmptyString)
        {
            if (categoryName != EmptyString)
            {
                return await this.furnitureRepo
                    .AllAsNoTracking()
                    .Where(f => f.Category.Name.ToLower().Contains(categoryName.ToLower()))
                    .ToArrayAsync();
            }

            return await this.furnitureRepo.All().ToArrayAsync();
        }

        public async Task<Furniture> GetById(string id)
        {
            return await this.furnitureRepo
                .AllAsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
