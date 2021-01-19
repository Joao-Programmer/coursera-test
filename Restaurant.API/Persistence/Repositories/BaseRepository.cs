using Restaurant.API.Persistence.Contexts;

namespace Restaurant.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;   
        }
    
    }
}