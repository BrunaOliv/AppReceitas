using AppReceitas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Category(1, "Sobremesas"),
                new Category(2, "Massas"),
                new Category(3, "Saladas e Molhos"),
                new Category(4, "Carnes"),
                new Category(5, "Bolos"),
                new Category(6, "Bebida"),
                new Category(7, "Lanches"),
                new Category(8, "Sopas")
                );
        }
    }
}
