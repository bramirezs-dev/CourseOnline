using System;
using System.Reflection.Emit;
using CourseOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseOnline.Infraestructure.Persistence.Configurations
{
    public class CourseInstructorConfiguration :IEntityTypeConfiguration<CourseInstructor>
    {
        

        public void Configure(EntityTypeBuilder<CourseInstructor> builder)
        {
            builder.ToTable("CursosInstructor");
            builder.HasKey(ci => new { ci.InstructorId, ci.CourseId });
            builder.Property(p => p.CourseId).HasColumnName("CursoId");
            builder.Property(p => p.InstructorId).HasColumnName("InstructorId");
        }
    }
}

