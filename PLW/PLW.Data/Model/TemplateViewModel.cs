using PLW.Data.Entity;

namespace PLW.Data.Model
{
    public class TemplateViewModel: Template
    {
        public int QuestionQuantity { get; set; }
        public int QuantityDone { get; set; }
        public decimal MaxScore { get; set; }
        public decimal MinScore { get; set; }
    }
}
