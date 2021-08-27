using System;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces

{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IAccountRepository Accounts { get; }
        IAccountTransactionRepository AccountTransactions { get; }
        Task<int> CommitAsync();
    }
}
