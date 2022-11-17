using AppReceitas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppReceitas.Infra.Data.EntitiesConfiguration
{
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Grade).IsRequired();
            builder.HasOne(e => e.Recipe).WithMany(e => e.Evaluations).HasForeignKey(e => e.RecipeId);
        }
    }
}
