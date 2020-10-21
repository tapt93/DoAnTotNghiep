using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Common.ApiResult
{
    public sealed class Message
    {
        private Message() { }

        public const string Success = "Success";
        public const string Error = "Error";
        public const string NoAuthorize = "No Authorize";
    }
}
