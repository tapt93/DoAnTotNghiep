using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Common.ApiResult
{
    public enum HttpStatus
    {
        OK = 200,

        InteralError = 500,

        NoAuthorize = 401,

        HandleError = 201
    }
}
