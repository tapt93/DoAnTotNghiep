namespace PLW.Data.Entity
{
    public class Template : BaseEntity
    {
        public string Content { get; set; }
        public int Duration { get; set; }
        public int Level { get; set; }
        public decimal PassScore { get; set; }
    }
}
