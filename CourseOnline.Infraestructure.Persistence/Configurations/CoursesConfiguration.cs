using System;
using CourseOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseOnline.Infraestructure.Persistence.Configurations
{
    public class CoursesConfiguration :IEntityTypeConfiguration<Course>
    {
        

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Cursos");
            builder.Property(p=>p.CourseId).HasColumnName("CursoId");

        }
    }
}

