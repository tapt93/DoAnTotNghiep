using Microsoft.EntityFrameworkCore;

namespace PLW.Data.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Template> Template { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Result> Result { get; set; }
    }
}
