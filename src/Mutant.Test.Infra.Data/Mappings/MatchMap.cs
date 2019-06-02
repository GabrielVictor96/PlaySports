using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaySports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Infra.Data.Mappings
{
    public class MatchMap : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("Match");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UsuarioCurtiu)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.UsuarioCurtido)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);
        }
    }
}
