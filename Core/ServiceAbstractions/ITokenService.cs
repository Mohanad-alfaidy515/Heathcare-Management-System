using Domain.Models;
using System.Security.Claims;

namespace ServiceAbstractions
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, IEnumerable<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
