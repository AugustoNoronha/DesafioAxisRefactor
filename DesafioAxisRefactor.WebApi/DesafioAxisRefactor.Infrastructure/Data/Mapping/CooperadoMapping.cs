using DesafioAxisRefactor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Infrastructure.Data.Mapping
{
    public sealed class CooperadoMapping : IEntityTypeConfiguration<Cooperado>
    {
        public void Configure(EntityTypeBuilder<Cooperado> entity)
        {
            entity.ToTable("cooperado", "dbo");

            entity.HasKey(x => x.Id);

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(40)
                .IsRequired();

            entity.Property(e => e.ContaCorrente)
             .HasColumnName("account_number")
             .HasMaxLength(12)
             .IsRequired();

            entity.HasOne(e => e.Cooperativa)
             .WithMany(e => e.Cooperados)
             .HasForeignKey(e => e.CooperativaId)
             .IsRequired();

            entity.HasMany(e => e.Favoritos)
                .WithOne(e => e.Cooperado)
                .HasForeignKey(e => e.CooperadoId)
                .IsRequired();
        }
    }
}
