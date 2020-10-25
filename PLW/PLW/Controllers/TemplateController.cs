using System;
using System.Web.Http;
using Framework.Common.ApiResult;
using Framework.Common.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PLW.BL.IBusinessLayer;
using PLW.Data.Model;

namespace PLW.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private ITemplateBLService _TemplateBLService;
        public TemplateController(ITemplateBLService TemplateBLService)
        {
            _TemplateBLService = TemplateBLService;
        }
        public ApiResult CreateTemplate(TemplateModel model)
        {
            var currentUser = HttpContext.User.Identity.GetUserAccount();
            try
            {
                return new ApiResult
                {
                    Status = HttpStatus.OK
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
    }
}