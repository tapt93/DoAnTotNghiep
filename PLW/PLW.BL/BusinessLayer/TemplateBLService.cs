using PLW.BL.IBusinessLayer;
using PLW.Data.Entity;
using PLW.Data.IService;
using PLW.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PLW.BL.BusinessLayer
{
    public class TemplateBLService : ITemplateBLService
    {
        private ITemplateService _TemplateService;
        private IQuestionService _QuestionService;
        private IAnswerService _AnswerService;

        public TemplateBLService(ITemplateService TemplateService, IQuestionService QuestionService, IAnswerService AnswerService)
        {
            _TemplateService = TemplateService;
            _QuestionService = QuestionService;
            _AnswerService = AnswerService;
        }

        public void CreateTemplate(TemplateModel model)
        {
            var template = new Template()
            {
                Content = model.Content,
                Duration = model.Duration,
                Level = model.Level,
                PassScore = model.PassScore,
                Skill = model.Skill
            };

            var newTemplate = _TemplateService.Add(template);

            foreach (var item in model.Questions)
            {
                var question = new Question()
                {
                    Content = item.Content,
                    TemplateId = newTemplate.ID
                };
                var newQuestion = _QuestionService.Add(question);
                var listAnswer = new List<Answer>();
                foreach (var ans in item.Answers)
                {
                    var answer = new Answer()
                    {
                        QuestionId = newQuestion.ID,
                        Content = ans.Content,
                        IsCorrect = ans.IsCorrect
                    };
                    listAnswer.Add(answer);
                }
                _AnswerService.Add(listAnswer);
            }
        }

        public TemplateModel GetTemplateForTest(int templateId)
        {
            var template = _TemplateService.Find(templateId);
            var templateModel = new TemplateModel()
            {
                Content = template.Content,
                Duration = template.Duration,
                PassScore = template.PassScore,
                Level = template.Level,
                Skill = template.Skill
            };

            var questions = _QuestionService.GetListQuestionByTemplateId(templateId).ToList();
            foreach (var question in questions)
            {
                var answers = _AnswerService.Get(c => c.QuestionId == question.ID);
                question.Answers = answers.ToList();
            }
            templateModel.Questions = questions;
            return templateModel;
        }
    }
}
