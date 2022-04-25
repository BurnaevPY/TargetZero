using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TargetZero.Domain;
using TargetZero.Domain.Abstractions;
using TargetZero.Infrastructure.Postgres.EntityConfigurations;

namespace TargetZero.Infrastructure.Postgres
{
    public class TargetZeroContext : DbContext, IUnitOfWork
    {
        public DbSet<Innovation> Innovations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Filial> Filials { get; set; }
        public DbSet<InnovationStatus> InnovationStatuses { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }
        public DbSet<Consideration> Considerations { get; set; }
        public DbSet<ConsiderationGroup> ConsiderationGroups { get; set; }
        public DbSet<ConsiderationResult> ConsiderationResults { get; set; }

        public TargetZeroContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // схема
            //modelBuilder.UseCollation("Cyrillic_General_CI_AS");

            //modelBuilder.HasDefaultSchema(Options.DefaultSchema);

            // конфигурации
            modelBuilder.ApplyConfiguration(new InnovationStatusEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FilialEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InnovationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ResolutionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ConsiderationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ConsiderationGroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ConsiderationResultEntityTypeConfiguration());

            // инциализация данными
            //modelBuilder.Entity<Filial>().HasData();

            modelBuilder.Entity<InnovationStatus>().HasData(Enumeration.GetAll<InnovationStatus>());
            modelBuilder.Entity<ConsiderationGroup>().HasData(Enumeration.GetAll<ConsiderationGroup>());
            modelBuilder.Entity<ConsiderationResult>().HasData(Enumeration.GetAll<ConsiderationResult>());

        }
    }
}
