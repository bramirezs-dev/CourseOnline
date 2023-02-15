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
            builder.Property(p=>p.Id).HasColumnName("CursoId");
            builder.Property(p => p.CoverPhoto).HasColumnName("foto_portada");
            builder.Property(p => p.Description).HasColumnName("descripcion");
            builder.Property(p => p.Title).HasColumnName("titulo");
            builder.Property(p => p.PublishDate).HasColumnName("fecha_publicacion");

        }
    }
}

