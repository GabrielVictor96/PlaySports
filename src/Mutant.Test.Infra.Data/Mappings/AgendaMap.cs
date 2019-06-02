using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaySports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Infra.Data.Mappings
{
    public class AgendaMap : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("Agenda");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Criador)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Membro1)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Membro2)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Membro3)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Membro4)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Membro5)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Membro6)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Membro7)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Membro8)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Membro9)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Atividade)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Local)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Data)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.Ativo)
                .IsRequired()
                .HasColumnType("varchar(5)")
                .HasMaxLength(100);
        }
    }
}
