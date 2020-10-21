using Framework.Common.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PLW.Data.Entity;
using PLW.Data.IService;
using PLW.Data.Model;

namespace PLW.Data.Service
{
    public class TemplateService : BaseService<Template, ApplicationDbContext>, ITemplateService
    {
        private readonly AppConfig _appConfig;
        private readonly string _connString;

        public TemplateService(ILogger<TemplateService> logger, ApplicationDbContext context,
        IConfiguration configuration, IOptions<AppConfig> AppConfig) : base(logger, context)
        {
            _appConfig = AppConfig.Value;
            _connString = configuration.GetConnectionString(_appConfig.ConnectionName);
        }
    }
}
