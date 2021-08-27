using Services.Exceptions;
using Services.Interfaces;
using System;
using System.Security.Claims;

namespace Services
{
    public class BaseService : IBaseService
    {
        public int GetCurrentUserId(ClaimsPrincipal claims)
        {
            string id = claims.FindFirst("id").Value;

            if (id == null)
            {
                throw new UnAuthorizedException();
            }

            int userId = Int32.Parse(id);

            return userId;
        }
    }
}
