using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaySports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Infra.Data.Mappings
{
    public class NovoMatchMap : IEntityTypeConfiguration<NovoMatch>
    {
        public void Configure(EntityTypeBuilder<NovoMatch> builder)
        {
            builder.ToTable("NovoMatch");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UsuarioPrimario)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.UsuarioSecundario)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);
        }
    }
}
