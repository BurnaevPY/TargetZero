using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TargetZero.Domain;

namespace TargetZero.Infrastructure.Postgres.EntityConfigurations
{
    internal class InnovationStatusEntityTypeConfiguration : IEntityTypeConfiguration<InnovationStatus>
    {
        public void Configure(EntityTypeBuilder<InnovationStatus> entity)
        {
            entity.ToTable("InnovationStatuses");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name);
        }
    }
}
