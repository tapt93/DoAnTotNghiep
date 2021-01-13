using System;
using Framework.Common.ApiResult;
using Framework.Common.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PLW.BL.IBusinessLayer;
using PLW.Data.Entity;
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

        [HttpPost]
        public ApiResult CreateTemplate(TemplateModel model)
        {            
            try
            {
                
                _TemplateBLService.CreateTemplate(model);
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

        [HttpGet]
        public ApiResult GetTemplateForTest(int templateId)
        {
            try
            {
                var result = _TemplateBLService.GetTemplateForTest(templateId);
                return new ApiResult
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

        [HttpPost]
        public ApiResult ListAll(TemplateSearchModel model)
        {
            try
            {
                var result = _TemplateBLService.ListAll(model);
                return new ApiResult
                {
                    Status = HttpStatus.OK,
                    Data = new
                    {
                        list = result,
                        model.Paging
                    }
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