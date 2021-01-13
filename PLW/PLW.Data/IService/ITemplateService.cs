using Framework.Common.Service;
using PLW.Data.Entity;
using PLW.Data.Model;
using System.Collections.Generic;

namespace PLW.Data.IService
{
    public interface ITemplateService : IBaseService<Template, ApplicationDbContext>
    {
        IList<TemplateViewModel> ListAll(TemplateSearchModel model);
    }
}
