using API.Course.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Course.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<ClassesDbContext>
    {
        public ClassesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClassesDbContext>();
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS01;Database=Course;Trusted_Connection=True");
            //optionsBuilder.UseSqlServer("Server=localhost;Database=Course;user=sa;password=App@223020");

            ClassesDbContext context = new ClassesDbContext(optionsBuilder.Options);

            return context;
        }
    }
}
