using System.Collections.Generic;
using System.Security.Claims;

namespace PracaDyplomowaBackend.Utilities.Providers.Interfaces
{
    public interface ITokenProvider
    {
        string BuildToken(List<Claim> claims);
    }
}
