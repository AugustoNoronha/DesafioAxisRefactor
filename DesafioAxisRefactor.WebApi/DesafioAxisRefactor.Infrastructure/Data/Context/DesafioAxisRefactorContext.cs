using DesafioAxisRefactor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Infrastructure.Data.Context
{
    public class DesafioAxisRefactorContext : DbContext
    {
        public DesafioAxisRefactorContext(DbContextOptions<DesafioAxisRefactorContext> options) : base(options)
        {

        }

        public DbSet<Cooperado> Cooperados { get; set; }
        public DbSet<Cooperativa> Cooperativas { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesafioAxisRefactorContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}

