using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaySports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Infra.Data.Mappings
{
    public class NotaMap : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.ToTable("Nota");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AgendaId)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Criador)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.NotaMembro1)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.NotaMembro2)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.NotaMembro3)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.NotaMembro4)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.NotaMembro5)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.NotaMembro6)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.NotaMembro7)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.NotaMembro8)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.NotaMembro9)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

        }
    }
}
