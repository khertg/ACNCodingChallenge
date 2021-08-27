using AutoMapper;
using Domain;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.DTO;
using Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Services.Exceptions;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._config = config;
        }

        public async Task<AuthSuccessDTO> Login(AuthenticationDTO request)
        {
            if (String.IsNullOrEmpty(request.email))
            {
                throw new ValidationException("Email is required.");
            }

            User user = await this._unitOfWork.Users.GetUser(request.email);

            if (user == null)
            {
                throw new NotFoundException();
            }

            bool isPasswordMatch = IsPasswordMatch(request.password, user.Password);

            if (!isPasswordMatch)
            {
                throw new BadRequestException();
            }

            UserDTO userDTO = this._mapper.Map<UserDTO>(user);
            AuthSuccessDTO authSuccess = GetToken(userDTO);

            return authSuccess;
        }

        private bool IsPasswordMatch(string requestPassword, string userPassword)
        {
            return requestPassword == userPassword;
        }

        private AuthSuccessDTO GetToken(UserDTO user)
        {
            // generate token that is valid for 7 days

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                    new Claim("Id", user.id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.email),
                };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                  claims,
                  expires: DateTime.UtcNow.AddDays(7),
                  signingCredentials: credentials);

            return new AuthSuccessDTO() { id = user.id, email = user.email, token = tokenHandler.WriteToken(token) };
        }
    }
}
