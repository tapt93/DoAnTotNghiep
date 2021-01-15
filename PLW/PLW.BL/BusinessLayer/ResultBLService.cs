using PLW.BL.IBusinessLayer;
using PLW.Data.Entity;
using PLW.Data.IService;
using PLW.Data.Model;
using System;
using System.Collections.Generic;

namespace PLW.BL.BusinessLayer
{
    public class ResultBLService : IResultBLService
    {
        private IResultService _ResultService;

        public ResultBLService(IResultService resultService)
        {
            _ResultService = resultService;
        }

        public void Add(Result result)
        {
            result.Created = DateTime.Now;
            _ResultService.Add(result);
        }

        public IList<ResultModel> GetResultsByAccount(string account)
        {
            return _ResultService.GetResultsByAccount(account);
        }
        public IList<ResultModel> GetResultReport()
        {
            return _ResultService.GetResultReport();
        }
    }
}
