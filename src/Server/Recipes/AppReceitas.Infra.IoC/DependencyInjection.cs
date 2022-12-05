using AppReceitas.Application.Interfaces;
using AppReceitas.Application.Mappings;
using AppReceitas.Application.Services;
using AppReceitas.Domain.Account;
using AppReceitas.Domain.Interfaces;
using AppReceitas.Infra.Data.Context;
using AppReceitas.Infra.Data.Indentity;
using AppReceitas.Infra.Data.Repositories;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Identity;
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
            services.AddScoped<IEvaluationRepository, EvaluationRepository>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILevelService, LevelService>();
            services.AddScoped<IEvaluationService, EvaluationService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddScoped<IBlobService, BlobService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
                options.AccessDeniedPath = "/Account/Login");

            services.AddScoped(x => new BlobServiceClient(configuration.GetConnectionString("AzureBlobStorage")));
            return services;
        }
    }
}
