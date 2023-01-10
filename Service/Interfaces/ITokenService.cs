using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ITokenService
    {
        string Create(Dictionary<string, string> Claims);
        ClaimsPrincipal Validate(string Token);
    }
}
