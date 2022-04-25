using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TargetZero.Domain;

namespace TargetZero.Infrastructure.Postgres.EntityConfigurations
{
    internal class ResolutionEntityTypeConfiguration : IEntityTypeConfiguration<Resolution>
    {
        public void Configure(EntityTypeBuilder<Resolution> entity)
        {
            entity.ToTable("Resolutions");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).ValueGeneratedOnAdd();

            entity.Property(x => x.Author);
            entity.Property(x => x.CreateTime);
            entity.Property(x => x.Content);
            entity.Property(x => x.ExecutionTime);
            entity.Property(x => x.InnovationId);

            entity.HasOne(x => x.InnovationStatus)
                .WithMany();

            entity.HasOne<Innovation>()
                .WithMany()
                .HasForeignKey(x => x.InnovationId);
        }
    }
}
