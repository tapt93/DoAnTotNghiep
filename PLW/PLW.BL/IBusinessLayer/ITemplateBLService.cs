using PLW.Data.Model;
using System.Collections.Generic;

namespace PLW.BL.IBusinessLayer
{
    public interface ITemplateBLService
    {
        void CreateTemplate(TemplateModel model);
        TemplateModel GetTemplateForTest(int templateId);
        IList<TemplateViewModel> ListAll(TemplateSearchModel model);
    }
}
