using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TargetZero.Domain;

namespace TargetZero.Infrastructure.Postgres.EntityConfigurations
{
    internal class ConsiderationGroupEntityTypeConfiguration : IEntityTypeConfiguration<ConsiderationGroup>
    {
        public void Configure(EntityTypeBuilder<ConsiderationGroup> entity)
        {
            entity.ToTable("ConsiderationGroups");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name);
        }
    }
}
