using Microsoft.EntityFrameworkCore;

namespace TaskApp.Models
{
    public class TaskContext : DbContext
    {

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Story> Stories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

}

