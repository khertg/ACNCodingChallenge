using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using System.Threading.Tasks;
using Services.Interfaces;
using System;
using Services.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Api.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("api/authenticate")]
        public async Task<ActionResult<AuthSuccessDTO>> Authenticate(AuthenticationDTO model)
        {
            try
            {
                AuthSuccessDTO result = await _userService.Login(model);
                return Ok(result);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { message = e.Message });
            }
            catch (Exception e)
            {
                if (e is NotFoundException || e is BadRequestException)
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong.");
            }
        }
    }
}
