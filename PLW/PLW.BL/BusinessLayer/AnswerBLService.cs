using PLW.BL.IBusinessLayer;
using PLW.Data.IService;

namespace PLW.BL.BusinessLayer
{
    public class AnswerBLService : IAnswerBLService
    {
        private IAnswerService _AnswerService;

        public AnswerBLService(IAnswerService AnswerService)
        {
            _AnswerService = AnswerService;
        }
    }
}
