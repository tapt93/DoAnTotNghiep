using IdentityServer.Service;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace IdentityServer.Configuration
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private IUsersService _UserService;
        private readonly PLW.Data.Model.AppConfig _appConfig;

        public ResourceOwnerPasswordValidator(IUsersService UsersService, IOptions<PLW.Data.Model.AppConfig> AppConfig)
        {
            _UserService = UsersService;
            _appConfig = AppConfig.Value;
        }
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var checkUserLogin = _UserService.CheckUserLogin(context.UserName, context.Password);
            if (checkUserLogin)
            {
                context.Result = new GrantValidationResult(
                     subject: context.UserName,
                     authenticationMethod: "custom"
                     );
                return Task.FromResult(context.Result);
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid user or password");
                return Task.FromResult(context.Result);
            }
        }
    }
}
