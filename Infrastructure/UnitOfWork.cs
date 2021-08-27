using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private UserRepository _userRepository;
        private AccountRepository _accRepository;
        private AccountTransactionRepository _accTranRepository;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public IAccountRepository Accounts => _accRepository = _accRepository ?? new AccountRepository(_context);

        public IAccountTransactionRepository AccountTransactions => _accTranRepository = _accTranRepository ?? new AccountTransactionRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
