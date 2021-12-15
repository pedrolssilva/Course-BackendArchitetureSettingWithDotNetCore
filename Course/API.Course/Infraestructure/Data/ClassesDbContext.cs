using API.Course.Business.Entities;
using API.Course.Infraestructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace API.Course.Infraestructure.Data
{
    public class ClassesDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Class> Class{ get; set; }

        public ClassesDbContext(DbContextOptions<ClassesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClassMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
