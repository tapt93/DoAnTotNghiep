namespace PLW.Data.Entity
{
    public class Result : BaseEntity
    {
        public decimal Score { get; set; }
        public string Account { get; set; }
        public int TemplateId { get; set; }
    }
}
