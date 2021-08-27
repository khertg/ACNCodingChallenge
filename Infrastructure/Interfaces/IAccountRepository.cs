using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAccountRepository
    {
        Task<decimal?> GetAccountBalance(int userId);
    }
}
