
using Restaurant.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.API.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}
