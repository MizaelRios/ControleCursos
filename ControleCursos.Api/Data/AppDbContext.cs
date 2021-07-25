using ControleCursos.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleCursos.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Curso> cursos { get; set; }
        public DbSet<Categoria> categoria { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .HasKey(c => c.Codigo);

            modelBuilder.Entity<Curso>()
                .Property(c => c.Codigo)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Curso>()
                .Property(c => c.DescricaoAssunto)
                .HasMaxLength(100);

            modelBuilder.Entity<Curso>()
               .Property(c => c.DescricaoAssunto)
               .IsRequired(true);

            modelBuilder.Entity<Curso>()
               .Property(c => c.DataInicio)
               .IsRequired(true);

            modelBuilder.Entity<Curso>()
               .Property(c => c.DataTermino)
               .IsRequired(true);

            modelBuilder.Entity<Categoria>()
                .HasKey(c => c.Codigo);

            modelBuilder.Entity<Categoria>()
                .Property(c => c.Descricao)
                .IsRequired(true);
            
            modelBuilder.Entity<Categoria>()
                .Property(c => c.Descricao)
                .HasMaxLength(20);
        }
    }
}
