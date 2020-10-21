using System.Data;

namespace Framework.Common.ApiResult
{
    public class ApiResult
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public HttpStatus Status { get; set; }

    }
}
