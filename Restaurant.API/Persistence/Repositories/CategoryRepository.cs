using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.API.Domain.Models;
using Restaurant.API.Domain.Repositories;
using Restaurant.API.Persistence.Contexts;

namespace Restaurant.API.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRespository
    {
        public CategoryRepository(AppDbContext context) : base(context){

        }

        public async Task<IEnumerable<Category>> ListAsync(){
            return await _context.Categories.ToListAsync();
        }

        // teste commit nova vm visualstudio 1.2
    }
}