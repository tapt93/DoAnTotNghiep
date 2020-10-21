using Framework.Common.Service;
using PLW.Data.Entity;

namespace PLW.Data.IService
{
    public interface IQuestionService : IBaseService<Question, ApplicationDbContext>
    {
    }
}
