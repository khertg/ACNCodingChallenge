using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class AccountTransactionRepository : IAccountTransactionRepository
    {
        protected readonly AppDbContext _context;
        public AccountTransactionRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<List<AccountTransaction>> GetAccountTransaction(int accountId)
        {
            return await this._context.AccountTransactions.Where(a => a.AccountId == accountId).ToListAsync();
        }
    }
}
