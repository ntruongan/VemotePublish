using Vemote.Application.DTOs;
using Vemote.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace Vemote.Application.AutoMappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();

            CreateMap<Users, UserDTO>();
            CreateMap<UserDTO, Users>();

            CreateMap<Banner, BannerDTO>();
            CreateMap<BannerDTO, Banner>(); 

            CreateMap<Product, ProductName>();
        }
    }
}
