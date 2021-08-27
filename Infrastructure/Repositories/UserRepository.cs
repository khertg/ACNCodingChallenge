using Domain;
using Infrastructure.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<User> GetUser(string email)
        {
            return await this._context.Users.Where(a => a.Email == email).SingleOrDefaultAsync();
        }
    }
}
