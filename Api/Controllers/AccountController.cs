using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Exceptions;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("balance")]
        public async Task<ActionResult<AccountBalanceDTO>> GetAccountBalance()
        {
            try
            {
                AccountBalanceDTO balance = await _accountService.GetAccountBalance(HttpContext.User);

                return Ok(balance);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong.");
            }
        }

        [HttpGet("transactions")]
        public async Task<ActionResult<IEnumerable<AccountTransactionDTO>>> GetAccountTransaction()
        {
            try
            {
                IEnumerable<AccountTransactionDTO> accountTransactions = await _accountService.GetAccountTransaction(HttpContext.User);

                return Ok(accountTransactions);
            }
            catch (UnAuthorizedException e)
            {
                return Unauthorized(new { message = e.Message });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong.");
            }
        }
    }
}
