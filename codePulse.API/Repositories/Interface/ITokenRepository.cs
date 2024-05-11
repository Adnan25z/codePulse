using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace codePulse.API.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
