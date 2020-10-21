using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Configuration
{
    public class ProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var claims = IdentityServerConfigurations.GetUserClaims(context.Subject.Identity.Name);
            context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();

            return Task.FromResult(context.IssuedClaims);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(true);
        }
    }

    
}
