using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PLW.BL.IBusinessLayer;

namespace PLW.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private IResultBLService _ResultBLService;
        public ResultController(IResultBLService ResultBLService)
        {
            _ResultBLService = ResultBLService;
        }
    }
}