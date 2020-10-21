namespace PLW.Data.Entity
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int AnswerId { get; set; }
    }
}
