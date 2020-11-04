using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Framework.Common.ApiResult;
using Framework.Common.Helpers;
using Framework.Common.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PLW.BL.IBusinessLayer;
using PLW.Data.Entity;
using PLW.Data.Model;

namespace PLW.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBLService _UserBLService;
        private AppConfig _appConfig;
        private readonly IJwtTokenManager _jwtTokenManager;
        public UserController(IUserBLService UserBLService, IOptions<AppConfig> AppConfig, IJwtTokenManager jwtTokenManager)
        {
            _UserBLService = UserBLService;
            _appConfig = AppConfig.Value;
            _jwtTokenManager = jwtTokenManager;
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<ApiResult> Authenticate([FromBody]LoginModel model)
        {

            bool checkUserLogin = _UserBLService.CheckUserLogin(model.Username, model.Password);
            if (checkUserLogin)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username)
                };
                var token = _jwtTokenManager.GenerateToken(claims);
                return new ApiResult
                {
                    Data = token,
                    Status = HttpStatus.OK
                };
            }
            else
            {
                return new ApiResult
                {
                    Data = null,
                    Message = Message.NoAuthorize,
                    Status = HttpStatus.NoAuthorize
                };
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public ApiResult Register([FromBody] User model)
        {
            try
            {
                string result = _UserBLService.RegisterUser(model);
                return new ApiResult()
                {
                    Status = HttpStatus.OK,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResult()
                {
                    Status = HttpStatus.InteralError,
                    Message = ex.Message
                };
            }
        }

        //[HttpGet]
        //public ApiResult CheckEmailExist(string email, string domain)
        //{
        //    try
        //    {
        //        var currentUser = HttpContext.User.Identity.GetUserAccount();
        //        var result = _UserBLService.Get(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
        //            && !c.Account.Equals(currentUser, StringComparison.OrdinalIgnoreCase));
        //        return new ApiResult()
        //        {
        //            Status = HttpStatus.OK,
        //            Data = result.Count
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiResult()
        //        {
        //            Status = HttpStatus.InteralError,
        //            Message = ex.Message
        //        };
        //    }
        //}

        [HttpGet]
        public ApiResult GetCurrentUserInfo()
        {
            try
            {
                var currentUser = User.FindFirstValue(ClaimTypes.Name);
                var result = _UserBLService.GetCurrentUserInfo("anhnt141");
                return new ApiResult()
                {
                    Status = HttpStatus.OK,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResult()
                {
                    Status = HttpStatus.InteralError,
                    Message = ex.Message
                };
            }
        }

        //[HttpPost]
        //public ApiResult UserChangePassword(ChangePasswordModel model)
        //{
        //    try
        //    {
        //        var currentUser = User.FindFirstValue(ClaimTypes.Name);
        //        if (string.IsNullOrEmpty(model.account) || !model.account.Equals(currentUser, StringComparison.OrdinalIgnoreCase))
        //        {
        //            return new ApiResult()
        //            {
        //                Status = HttpStatus.InteralError,
        //                Data = false
        //            };
        //        }


        //        bool result = _UsersBLService.UserChangePassword(model);
        //        return new ApiResult()
        //        {
        //            Status = HttpStatus.OK,
        //            Data = result
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiResult()
        //        {
        //            Status = HttpStatus.InteralError,
        //            Message = ex.Message
        //        };
        //    }
        //}

        //[HttpPost]
        //public ApiResult UpdateUserInfo(Users model)
        //{
        //    try
        //    {
        //        var currentUser = User.FindFirstValue(ClaimTypes.Name);
        //        if (string.IsNullOrEmpty(model.Account) || !model.Account.Equals(currentUser, StringComparison.OrdinalIgnoreCase))
        //        {
        //            return new ApiResult()
        //            {
        //                Status = HttpStatus.InteralError,
        //                Data = false
        //            };
        //        }

        //        _UsersBLService.UpdateUserInfo(model);
        //        return new ApiResult()
        //        {
        //            Status = HttpStatus.OK,
        //            Data = null
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiResult()
        //        {
        //            Status = HttpStatus.InteralError,
        //            Message = ex.Message
        //        };
        //    }
        //}
    }
}