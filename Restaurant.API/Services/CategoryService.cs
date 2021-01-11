using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.API.Domain.Models;
using Restaurant.API.Domain.Repositories;
using Restaurant.API.Domain.Services;

namespace Restaurant.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRespository _categoryRepository;

        public CategoryService(ICategoryRespository categoryRepository){
            this._categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> ListAsync(){
            return await _categoryRepository.ListAsync();
        }
        
    }
}