using DesafioAxisRefactor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Infrastructure.Data.Mapping
{
    public sealed class CooperativasMapping : IEntityTypeConfiguration<Cooperativa>
    {
        public void Configure(EntityTypeBuilder<Cooperativa> entity)
        {
            entity.ToTable("cooperativas", "dbo");

            entity.HasKey(x => x.Id);

            entity.Property(e => e.Description)
                .HasColumnName("descripition")
                .HasMaxLength(250)
                .IsRequired();

            entity.HasMany(e => e.Cooperados)
                .WithOne(e => e.Cooperativa)
                .HasForeignKey(e => e.CooperativaId)
                .IsRequired();
        }
    }
}
