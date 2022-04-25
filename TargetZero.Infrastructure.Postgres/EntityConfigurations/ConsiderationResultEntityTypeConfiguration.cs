using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TargetZero.Domain;

namespace TargetZero.Infrastructure.Postgres.EntityConfigurations
{
    internal class ConsiderationResultEntityTypeConfiguration : IEntityTypeConfiguration<ConsiderationResult>
    {
        public void Configure(EntityTypeBuilder<ConsiderationResult> entity)
        {
            entity.ToTable("ConsiderationResults");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name);
        }
    }
}
