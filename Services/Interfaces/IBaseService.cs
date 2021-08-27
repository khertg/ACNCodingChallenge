using System.Security.Claims;

namespace Services.Interfaces
{
    public interface IBaseService
    {
        int GetCurrentUserId(ClaimsPrincipal claims);
    }
}
