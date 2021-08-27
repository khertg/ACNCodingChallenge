using Domain;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(string email);
    }
}
