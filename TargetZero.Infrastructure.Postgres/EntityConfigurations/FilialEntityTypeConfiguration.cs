using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TargetZero.Domain;

namespace TargetZero.Infrastructure.Postgres.EntityConfigurations
{
    internal class FilialEntityTypeConfiguration : IEntityTypeConfiguration<Filial>
    {
        public void Configure(EntityTypeBuilder<Filial> entity)
        {
            entity.ToTable("Filials");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name);
        }
    }
}
