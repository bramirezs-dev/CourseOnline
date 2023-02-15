using System;
using CourseOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseOnline.Infraestructure.Persistence.Configurations
{
    public class InstructorsConfiguration :IEntityTypeConfiguration<Instructor>
    {
        

        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructores");
            builder.Property(p=>p.Id).HasColumnName("InstructorId");
            builder.Property(p => p.Grade).HasColumnName("grado");
            builder.Property(p => p.LastName).HasColumnName("apellido");
            builder.Property(p => p.Name).HasColumnName("nombre");
            builder.Property(p => p.ProfilePhoto).HasColumnName("foto_perfil");

        }
    }
}

