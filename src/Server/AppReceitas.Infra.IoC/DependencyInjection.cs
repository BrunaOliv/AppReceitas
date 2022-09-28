using AppReceitas.Application.Interfaces;
using AppReceitas.Application.Mappings;
using AppReceitas.Application.Services;
using AppReceitas.Domain.Interfaces;
using AppReceitas.Infra.Data.Context;
using AppReceitas.Infra.Data.Repositories;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppReceitas.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRecipesRepository, RecipeRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILevelService, LevelService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddScoped<IBlobService, BlobService>();

            services.AddScoped(x => new BlobServiceClient(configuration.GetConnectionString("AzureBlobStorage")));
            return services;
        }
    }
}
