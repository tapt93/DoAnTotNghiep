using PLW.Data.Model;

namespace PLW.BL.IBusinessLayer
{
    public interface ITemplateBLService
    {
        void CreateTemplate(TemplateModel model);
        TemplateModel GetTemplateForTest(int templateId);
    }
}
