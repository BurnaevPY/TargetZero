using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TargetZero.Domain;

namespace TargetZero.Infrastructure.Postgres.EntityConfigurations
{
    internal class ConsiderationEntityTypeConfiguration : IEntityTypeConfiguration<Consideration>
    {
        public void Configure(EntityTypeBuilder<Consideration> entity)
        {
            entity.ToTable("Considerations");

            entity.HasKey(x => x.Id);
            entity.HasAlternateKey("InnovationId", "ConsiderationGroupId");

            entity.Property(x => x.Id).ValueGeneratedOnAdd();

            entity.Property(x => x.Content);
            entity.Property(x => x.InnovationId);

            entity.HasOne<Innovation>()
                .WithMany()
                .HasForeignKey(x => x.InnovationId);

            //entity.HasOne(x => x.InnovationStatus)
            //    .WithMany();

            entity.HasOne(x => x.ConsiderationGroup)
                .WithMany();

            entity.HasOne(x => x.ConsiderationResult)
                .WithMany();
                
        }
    }
}
