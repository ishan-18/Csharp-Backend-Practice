using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Models;
using AutoMapper;

namespace api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<ProductCreateDTO, Product>();
            CreateMap<Product, ProductCreateDTO>();

            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<Product, ProductUpdateDTO>();

            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();

            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<Category, CategoryCreateDTO>();

            CreateMap<CategoryUpdateDTO, Category>();
            CreateMap<Category, CategoryUpdateDTO>();
        }
    }
}