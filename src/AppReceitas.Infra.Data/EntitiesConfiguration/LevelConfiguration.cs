using AppReceitas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppReceitas.Infra.Data.EntitiesConfiguration
{
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Level> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Level(1, "Fácil"),
                new Level(2, "Médio"),
                new Level(3, "Deficíl"),
                new Level(4, "Mestre cuca")
                );
        }
    }
}
