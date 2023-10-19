using DesafioAxisRefactor.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Infrastructure.Data.Mapping
{
    public sealed class FavoritoMapping : IEntityTypeConfiguration<Favorito>
    {
        public void Configure(EntityTypeBuilder<Favorito> entity)
        {
            entity.ToTable("favoritos", "dbo");

            entity.HasKey(x => x.Id);

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(40)
                .IsRequired();

            entity.Property(e => e.PixType)
            .HasColumnName("pix_type")
            .HasMaxLength(2)
            .IsRequired();

            entity.Property(e => e.PixKey)
            .HasColumnName("pix_key")
            .HasMaxLength(40)
            .IsRequired();

            entity.HasOne(e => e.Cooperado)
                .WithMany(e => e.Favoritos)
                .HasForeignKey(e => e.CooperadoId)
                .IsRequired();

        }
    }
}
