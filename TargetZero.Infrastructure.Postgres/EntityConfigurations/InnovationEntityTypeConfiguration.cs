using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TargetZero.Domain;

namespace TargetZero.Infrastructure.Postgres.EntityConfigurations
{
    internal class InnovationEntityTypeConfiguration : IEntityTypeConfiguration<Innovation>
    {
        public void Configure(EntityTypeBuilder<Innovation> entity)
        {
            entity.ToTable("Innovations");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Id).HasIdentityOptions(startValue: 100100);

            entity.Property(x => x.Author);
            entity.Property(x => x.CreateTime);
            entity.Property(x => x.CurrentState);
            entity.Property(x => x.Description);
            entity.Property(x => x.Reason);
            entity.Property(x => x.TargetState);
            entity.Property(x => x.IsActual).HasDefaultValue(true);
            entity.Property("InnovationStatusId")
                .IsRequired()
                .HasDefaultValue(InnovationStatus.Consideration.Id);

            entity.Property("CategoryId")
                .IsRequired();
            entity.Property("FilialId")
                .IsRequired();

            entity.HasOne(x => x.Category)
                .WithMany();

            entity.HasOne(x => x.Filial)
                .WithMany();

            entity.HasOne(x => x.InnovationStatus)
                .WithMany();
        }
    }
}
