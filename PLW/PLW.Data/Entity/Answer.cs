namespace PLW.Data.Entity
{
    public class Answer : BaseEntity
    {
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
