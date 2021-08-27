
using Services.DTO;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthSuccessDTO> Login(AuthenticationDTO request);
    }
}
