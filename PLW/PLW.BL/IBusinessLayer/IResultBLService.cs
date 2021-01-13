using PLW.Data.Entity;
using PLW.Data.Model;
using System.Collections.Generic;

namespace PLW.BL.IBusinessLayer
{
    public interface IResultBLService
    {
        void Add(Result result);
        IList<ResultModel> GetResultsByAccount(string account);
    }
}
