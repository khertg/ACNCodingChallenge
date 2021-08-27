
using AutoMapper;
using Domain;
using Infrastructure.Interfaces;
using Services.DTO;
using Services.Exceptions;
using Services.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<AccountBalanceDTO> GetAccountBalance(ClaimsPrincipal claims)
        {
            int userId = this.GetCurrentUserId(claims);

            decimal? balance = await this._unitOfWork.Accounts.GetAccountBalance(userId);

            if(balance == null)
            {
                throw new NotFoundException("Account not found.");
            }

            AccountBalanceDTO balanceDTO = this._mapper.Map<AccountBalanceDTO>(balance);

            return balanceDTO;
        }

        public async Task<List<AccountTransactionDTO>> GetAccountTransaction(ClaimsPrincipal claims)
        {
            int userId = this.GetCurrentUserId(claims);

            List<AccountTransaction> accTranList = await this._unitOfWork.AccountTransactions.GetAccountTransaction(userId);
            List<AccountTransactionDTO> accTranDTOList = this._mapper.Map<List<AccountTransactionDTO>>(accTranList);

            return accTranDTOList;
        }
    }
}
