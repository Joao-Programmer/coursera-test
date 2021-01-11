using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.API.Domain.Models;

namespace Restaurant.API.Domain.Repositories
{
    public interface ICategoryRespository
    {
         Task<IEnumerable<Category>> ListAsync();
    }
}