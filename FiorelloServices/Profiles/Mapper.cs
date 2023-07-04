using AutoMapper;
using Fiorello.Core.Entities;
using Fiorello.Services.Dtos.CategoryDtos;
using Fiorello.Services.Dtos.FlowerDtos;
using Microsoft.AspNetCore.Http;

namespace ApiProject.Services.Profiles
{
    public class Mapper : Profile
    {
        public Mapper(IHttpContextAccessor accessor)
        {
            var uriBuilder = new UriBuilder(accessor.HttpContext.Request.Scheme, accessor.HttpContext.Request.Host.Host, accessor.HttpContext.Request.Host.Port ?? -1);
            if (uriBuilder.Uri.IsDefaultPort)
            {
                uriBuilder.Port = -1;
            }
            string baseUrl = uriBuilder.Uri.AbsoluteUri;
            CreateMap<Category, CategoryGetDto>();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<Category, CategoryGetAllItemDto>();
            CreateMap<FlowerPostDto, Flower>();
            CreateMap<Flower, FlowerGetAllItemDto>()
                .ForMember(dest => dest.ImageUrl, m => m.MapFrom(s => s.ImageName == null ? null : baseUrl + $"uploads/flowers/{s.ImageName}"));
            
            CreateMap<Flower, FlowerGetDto>()
                .ForMember(dest => dest.ImageUrl, m => m.MapFrom(s => s.ImageName == null?null: baseUrl + $"uploads/flowers/{s.ImageName}"));
            CreateMap<Category, CategoryInFlowerGetDto>();
                
        }
    }
}
