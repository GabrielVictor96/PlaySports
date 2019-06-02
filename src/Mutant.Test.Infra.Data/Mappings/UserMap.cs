using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaySports.Domain.Entities;

namespace PlaySports.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Sexo)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(x => x.Login)
                .IsRequired()
                .HasColumnType("varchar(60)")
                .HasMaxLength(60);

            builder.Property(x => x.Esporte)
                .IsRequired()
                .HasColumnType("varchar(20)")
                .HasMaxLength(60);

            builder.Property(x => x.Nivel)
                .IsRequired()
                .HasColumnType("varchar(15)")
                .HasMaxLength(60);

            builder.Property(x => x.Localizacao)
                .IsRequired()
                .HasColumnType("varchar(60)")
                .HasMaxLength(60);

            builder.OwnsOne(x => x.Senha)
                .Property(x => x.SenhaCriptografada)
                .IsRequired()
                .HasColumnName("SenhaCriptografada")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.Imagem)
                .IsRequired()
                .HasColumnType("image");
        }
    }
}