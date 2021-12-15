using API.Course.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Course.Infraestructure.Data.Mappings
{
    public class ClassMapping : IEntityTypeConfiguration<Class>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("TB_CLASS");
            builder.HasKey(p => p.Code);
            builder.Property(p => p.Code).ValueGeneratedOnAdd();
            builder.Property(p => p.Name);
            builder.Property(p => p.Description);
            builder.HasOne(p => p.User).WithMany().HasForeignKey(fk => fk.UserCode);
        }
    }
}
