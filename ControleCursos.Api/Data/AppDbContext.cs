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
                .HasKey(c => c.codigo);

            modelBuilder.Entity<Curso>()
                .Property(c => c.codigo)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Curso>()
                .Property(c => c.descricaoAssunto)
                .HasMaxLength(100);

            modelBuilder.Entity<Curso>()
               .Property(c => c.descricaoAssunto)
               .IsRequired(true);

            modelBuilder.Entity<Curso>()
               .Property(c => c.dataInicio)
               .IsRequired(true);

            modelBuilder.Entity<Curso>()
               .Property(c => c.dataTermino)
               .IsRequired(true);

            modelBuilder.Entity<Categoria>()
                .HasKey(c => c.codigo);

            modelBuilder.Entity<Categoria>()
                .Property(c => c.descricao)
                .IsRequired(true);
            
            modelBuilder.Entity<Categoria>()
                .Property(c => c.descricao)
                .HasMaxLength(20);
        }
    }
}
