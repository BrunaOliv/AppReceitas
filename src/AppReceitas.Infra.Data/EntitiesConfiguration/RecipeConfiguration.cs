using AppReceitas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppReceitas.Infra.Data.EntitiesConfiguration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipes>
    {
        public void Configure(EntityTypeBuilder<Recipes> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Ingredients).IsRequired();
            builder.Property(p => p.PreparationMode).IsRequired();
            builder.HasOne(e => e.Category).WithMany(e => e.Recipes).HasForeignKey(e => e.CategoryId);
            builder.HasOne(e => e.Level).WithMany(e => e.Recipes).HasForeignKey(e => e.LevelId);
        }
    }
}
