﻿using AutoMapper;
using Demo_Project_4REST_API_Course.Models;

namespace Demo_Project_4REST_API_Course.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseEntity, Course>()
                .ForMember(dest => dest.Creditos, opt => opt.MapFrom(src => src.Creditos))
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src =>
                    Link.To(
                        nameof(Controllers.CoursesController.GetcourseById),
                        new { courseId = src.Id })))
                .ReverseMap();

            CreateMap<CycleEntity, Cycle>()
                .ForMember(dest => dest.Promedio, opt => opt.MapFrom(src => src.Promedio))
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src =>
                    Link.To(
                        nameof(Controllers.CyclesController.GetCycleById),
                        new { cycleId = src.Id })))
                .ReverseMap();
        }
    }
}
