using System.Collections.Generic;
using System.Security.Claims;

namespace ExCursed.BLL.Interfaces
{
    public interface IAuthTokenGenerator
    {
        string GenerateTokenForClaims(IEnumerable<Claim> userClaims);
    }
}
