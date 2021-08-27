using Services.DTO;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountBalanceDTO> GetAccountBalance(ClaimsPrincipal claims);
        Task<List<AccountTransactionDTO>> GetAccountTransaction(ClaimsPrincipal claims);
    }
}
