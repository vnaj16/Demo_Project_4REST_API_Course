using AutoMapper;
using Demo_Project_4REST_API_Course.Models;

namespace Demo_Project_4REST_API_Course.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseEntity, Course>()
                .ForMember(dest => dest.Creditos, opt => opt.MapFrom(src => src.Creditos))
                .ReverseMap();

            CreateMap<CycleEntity, Cycle>()
                .ForMember(dest => dest.Promedio, opt => opt.MapFrom(src => src.Promedio))
                .ReverseMap();
        }
    }
}
