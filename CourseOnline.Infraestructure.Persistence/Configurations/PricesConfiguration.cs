using System;
using CourseOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseOnline.Infraestructure.Persistence.Configurations
{
    public class PricesConfiguration :IEntityTypeConfiguration<Price>
    {
        

        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("Precios");
            builder.Property(p=>p.Id).HasColumnName("PrecioId");
            builder.Property(p => p.CourseId).HasColumnName("CursoId");
            builder.Property(p => p.CurrentPrice).HasColumnName("precio_actual");
            builder.Property(p => p.Promotion).HasColumnName("promosion");
        }
    }
}

