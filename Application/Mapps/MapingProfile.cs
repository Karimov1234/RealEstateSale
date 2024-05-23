using Application.DTOs.AgentDtos;
using Application.DTOs.CategoryDtos;
using Application.DTOs.CityDtos;
using Application.DTOs.ImageDtos;
using Application.DTOs.OwnerDtos;
using Application.DTOs.PropertyDtos;
using Application.DTOs.RegionOfCity;
using Application.DTOs.ReviewDtos;
using Application.DTOs.UserDtos;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Identities;

namespace Application.Mapps
{
    public class MapingProfile:Profile
    {
        public MapingProfile()
        {

            CreateMap<ReviewCreateDTO, Review>().ReverseMap();
            CreateMap<ReviewGetDTO, Review>().ReverseMap();
            CreateMap<ReviewUpdateDTO, Review>().ReverseMap();
            CreateMap<GetOwnerDTO, Owner>().ReverseMap();
            CreateMap<CreateUpdateOwnerDTO, Owner>().ReverseMap();
            CreateMap<GetCityDTO,City>().ReverseMap();
            CreateMap<CreateUpdateCityDTO, City>().ReverseMap();
            CreateMap<GetImageDTO, Image>().ReverseMap();
            CreateMap<CreateUpdateImageDTO, Image>().ReverseMap();
            CreateMap<GetAgentDTO, Agent>().ReverseMap();
            CreateMap<CreateUpdateAgentDTO, Agent>().ReverseMap();
            CreateMap<GetRegionDTO, RegionOfCity>().ReverseMap();
            CreateMap<CreateUpdateRegionDTO, RegionOfCity>().ReverseMap();
            CreateMap<CreatePropertyDTO, Property>().ReverseMap();
            CreateMap<UpdatePropertyDTO, Property>().ReverseMap();
            CreateMap<GetPropertyDTO, Property>().ReverseMap();
            CreateMap<GetUserDTO, AppUser>().ReverseMap();
            CreateMap<CreateUserDTO, AppUser>().ReverseMap();
            CreateMap<UpdateUserDTO, AppUser>().ReverseMap();
            CreateMap<GetCategoryDTO, Category>().ReverseMap();
            CreateMap<CreateUpdateCategoryDTO, Category>().ReverseMap();


        }
    }
}
