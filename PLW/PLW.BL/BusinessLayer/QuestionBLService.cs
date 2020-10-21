using PLW.BL.IBusinessLayer;
using PLW.Data.IService;

namespace PLW.BL.BusinessLayer
{
    public class QuestionBLService : IQuestionBLService
    {
        private IQuestionService _QuestionService;

        public QuestionBLService(IQuestionService QuestionService)
        {
            _QuestionService = QuestionService;
        }
    }
}
