using System;
using Framework.Common.ApiResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PLW.BL.IBusinessLayer;
using PLW.Data.Entity;

namespace PLW.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private IResultBLService _ResultBLService;
        public ResultController(IResultBLService ResultBLService)
        {
            _ResultBLService = ResultBLService;
        }

        [HttpPost]
        public ApiResult Add([FromBody]Result model)
        {
            try
            {
                _ResultBLService.Add(model);
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
        public ApiResult GetResultsByAccount(string account)
        {
            try
            {
                return new ApiResult
                {
                    Data = _ResultBLService.GetResultsByAccount(account),
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