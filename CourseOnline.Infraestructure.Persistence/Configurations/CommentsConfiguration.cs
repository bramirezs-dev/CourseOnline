using System;
using CourseOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseOnline.Infraestructure.Persistence.Configurations
{
    public class CommentsConfiguration :IEntityTypeConfiguration<Comment>
    {
        

        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comentarios");
            builder.Property(p=>p.Id).HasColumnName("ComentarioId");
            builder.Property(p => p.Score).HasColumnName("Puntaje");
            builder.Property(p => p.Student).HasColumnName("Estudiante");
            builder.Property(p => p.TextComment).HasColumnName("texto_comentario");
            builder.Property(p => p.CourseId).HasColumnName("CursoId");
        }
    }
}

