using Framework.Common.Service;
using PLW.Data.Entity;
using PLW.Data.Model;
using System.Collections.Generic;

namespace PLW.Data.IService
{
    public interface IResultService : IBaseService<Result, ApplicationDbContext>
    {
        IList<ResultModel> GetResultsByAccount(string account);
    }
}
