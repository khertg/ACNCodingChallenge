using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        protected readonly AppDbContext _context;
        public AccountRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<decimal?> GetAccountBalance(int userId)
        {
            decimal? balance = await _context.Accounts.Where(a => a.UserId == userId).Select(a => a.Balance).FirstOrDefaultAsync();
            return balance;
        }
    }
}
