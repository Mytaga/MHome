using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MHome.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepo;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public IQueryable<Category> All()
        {
            return this.categoryRepo.AllAsNoTracking();
        }
    }
}
