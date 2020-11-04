using Framework.Common.Service;
using PLW.Data.Entity;
using PLW.Data.Model;
using System.Collections.Generic;

namespace PLW.Data.IService
{
    public interface IQuestionService : IBaseService<Question, ApplicationDbContext>
    {
        IList<QuestionModel> GetListQuestionByTemplateId(int templateId);
    }
}
