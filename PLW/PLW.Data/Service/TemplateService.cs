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

        public IList<TemplateViewModel> ListAll(TemplateSearchModel model)
        {
            try
            {
                IQueryable<TemplateViewModel> list;
                if (string.IsNullOrEmpty(model.Skill))
                {
                    list = from template in dc.Template
                           select new TemplateViewModel
                           {
                               Content = template.Content,
                               Created = template.Created,
                               Duration = template.Duration,
                               ID = template.ID,
                               PassScore = template.PassScore,
                               Skill = template.Skill,
                               QuestionQuantity = dc.Question.Where(c => c.TemplateId == template.ID).Count()
                           };
                }
                else
                {
                    list = from template in dc.Template
                           where template.Skill.ToLower().Contains(model.Skill.ToLower())
                           select new TemplateViewModel
                           {
                               Content = template.Content,
                               Created = template.Created,
                               Duration = template.Duration,
                               ID = template.ID,
                               PassScore = template.PassScore,
                               Skill = template.Skill,
                               QuestionQuantity = dc.Question.Where(c => c.TemplateId == template.ID).Count()
                           };
                }
               
                model.Paging.RowsCount = list.Count();
                return list.Skip(model.Paging.PageSize * (model.Paging.CurrentPage - 1)).Take(model.Paging.PageSize).ToList();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
