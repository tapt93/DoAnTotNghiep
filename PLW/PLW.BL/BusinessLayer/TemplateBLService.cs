using PLW.BL.IBusinessLayer;
using PLW.Data.IService;

namespace PLW.BL.BusinessLayer
{
    public class TemplateBLService : ITemplateBLService
    {
        private ITemplateService _TemplateService;

        public TemplateBLService(ITemplateService TemplateService)
        {
            _TemplateService = TemplateService;
        }
    }
}
