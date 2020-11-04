using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PLW.BL.BusinessLayer;
using PLW.BL.IBusinessLayer;
using PLW.Data.IService;
using PLW.Data.Service;

namespace PLW.Api.Configuration
{
    public static class DIConfigurator
    {
        public static void ConfigDI(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserBLService, UserBLService>();

            services.AddScoped<ITemplateBLService, TemplateBLService>();
            services.AddScoped<ITemplateService, TemplateService>();

            services.AddScoped<IQuestionBLService, QuestionBLService>();
            services.AddScoped<IQuestionService, QuestionService>();

            services.AddScoped<IAnswerBLService, AnswerBLService>();
            services.AddScoped<IAnswerService, AnswerService>();

            services.AddScoped<IResultBLService, ResultBLService>();
            services.AddScoped<IResultService, ResultService>();
        }
    }
}
