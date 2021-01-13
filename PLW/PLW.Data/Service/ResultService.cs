using Framework.Common.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PLW.Data.Entity;
using PLW.Data.IService;
using PLW.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace PLW.Data.Service
{
    public class ResultService : BaseService<Result, ApplicationDbContext>, IResultService
    {
        private readonly AppConfig _appConfig;
        private readonly string _connString;

        public ResultService(ILogger<ResultService> logger, ApplicationDbContext context,
        IConfiguration configuration, IOptions<AppConfig> AppConfig) : base(logger, context)
        {
            _appConfig = AppConfig.Value;
            _connString = configuration.GetConnectionString(_appConfig.ConnectionName);
        }

        public IList<ResultModel> GetResultsByAccount(string account)
        {
            var data = from result in dc.Result
                       join template in dc.Template on result.TemplateId equals template.ID
                       where result.Account.ToLower() == account.ToLower()
                       select new ResultModel
                       {
                           Account = result.Account,
                           Created = result.Created,
                           ID = result.ID,
                           Score = result.Score,
                           TemplateId = result.TemplateId,
                           Updated = result.Updated,
                           TestName = template.Content
                       };
            return data.ToList();
        }
    }
}
