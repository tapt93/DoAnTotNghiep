using PLW.Data.Entity;
using System.Collections.Generic;

namespace PLW.Data.Model
{
    public class QuestionModel : Question
    {
        public List<Answer> Answers { get; set; }
    }
}
