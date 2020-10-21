using Framework.Common.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PLW.Data.Entity;
using PLW.Data.IService;
using PLW.Data.Model;

namespace PLW.Data.Service
{
    public class QuestionService : BaseService<Question, ApplicationDbContext>, IQuestionService
    {
        private readonly AppConfig _appConfig;
        private readonly string _connString;

        public QuestionService(ILogger<QuestionService> logger, ApplicationDbContext context,
        IConfiguration configuration, IOptions<AppConfig> AppConfig) : base(logger, context)
        {
            _appConfig = AppConfig.Value;
            _connString = configuration.GetConnectionString(_appConfig.ConnectionName);
        }
    }
}
