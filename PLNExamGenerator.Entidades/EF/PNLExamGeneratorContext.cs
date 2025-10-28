﻿using Microsoft.EntityFrameworkCore;
using PNLExamGenerator.Entidades;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PNLExamGenerator.Entidades.EF
{
    public class PNLExamGeneratorContext : DbContext
    {
        public PNLExamGeneratorContext() { }

        public PNLExamGeneratorContext(DbContextOptions<PNLExamGeneratorContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=PNLExamGenerator;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Password).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Nombre).HasMaxLength(200);
            });
        }
    }
}

