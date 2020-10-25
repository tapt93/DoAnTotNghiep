using PLW.Data.Entity;
using System.Collections.Generic;

namespace PLW.Data.Model
{
    public class TemplateModel : Template
    {
        public List<QuestionModel> Questions { get; set; }
    }
}
