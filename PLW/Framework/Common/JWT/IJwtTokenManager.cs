using System.Collections.Generic;
using System.Security.Claims;

namespace Framework.Common.JWT
{
    public interface IJwtTokenManager
    {
        string GenerateToken(List<Claim> claims);
    }
}