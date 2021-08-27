using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAccountTransactionRepository
    {
        Task<List<AccountTransaction>> GetAccountTransaction(int accountId);
    }
}
