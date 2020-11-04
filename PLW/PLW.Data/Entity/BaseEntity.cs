using System;

namespace PLW.Data.Entity
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
