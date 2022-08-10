using AutoMapper;
using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Services.Catalog.Models;

namespace FreeCourse.Services.Catalog.Mappers;

public class GeneralMapperProfile:Profile
{
    public GeneralMapperProfile()
    {
        CreateMap<Course, CourseDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Feature, FeatureDto>().ReverseMap();
    }
}