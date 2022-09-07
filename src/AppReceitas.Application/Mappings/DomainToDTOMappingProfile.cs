using AppReceitas.Application.DTOs;
using AppReceitas.Domain.Entities;
using AppReceitas.Domain.Filters;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Application.Mappings
{
    public class DomainToDTOMappingProfile: Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Recipes, RecipeDTO>().ReverseMap();
            CreateMap<PaginationFilter<Recipes>, PaginationFilterResult<RecipeDTO>>().ReverseMap();
            CreateMap<PaginationFilter<Recipes>, PaginationFilterRequest>().ReverseMap();
        }
    }
}
