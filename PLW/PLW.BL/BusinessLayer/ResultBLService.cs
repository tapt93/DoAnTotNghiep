using PLW.BL.IBusinessLayer;
using PLW.Data.IService;

namespace PLW.BL.BusinessLayer
{
    public class ResultBLService : IResultBLService
    {
        private IResultService _ResultService;

        public ResultBLService(IResultService resultService)
        {
            _ResultService = resultService;
        }
    }
}
