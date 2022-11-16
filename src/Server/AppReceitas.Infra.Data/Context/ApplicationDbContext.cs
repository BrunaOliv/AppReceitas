﻿using AppReceitas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppReceitas.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<Evaluation> Evaluation { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
