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
    public class AnswerController : ControllerBase
    {
        private IAnswerBLService _AnswerBLService;
        public AnswerController(IAnswerBLService AnswerBLService)
        {
            _AnswerBLService = AnswerBLService;
        }
    }
}