using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo_Project_4REST_API_Course.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Project_4REST_API_Course.Services
{
    public class CourseService : ICourseService
    {
        private readonly ControlNotasDbContext _controlNotasDbContext;
        private readonly IConfigurationProvider _mappingConfiguration;
        public CourseService(ControlNotasDbContext controlNotasDbContext, IConfigurationProvider mappingConfiguration)
        {
            _controlNotasDbContext = controlNotasDbContext;
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<int> CreateCourseAsync(CourseForm courseForm)
        {
            CourseEntity courseEntity = new CourseEntity()
            {
                Codigo = courseForm.Codigo,
                Creditos = courseForm.Creditos,
                IdCiclo = courseForm.IdCiclo,
                Nombre = courseForm.Nombre,
                Promedio = 0,
                Id = new Random().Next(10, 20)
            };

            var entity = await _controlNotasDbContext.Courses.AddAsync(courseEntity);

            var created = await _controlNotasDbContext.SaveChangesAsync();

            if (created < 1)
            {
                throw new InvalidOperationException("Could not created the course");
            }

            return entity.Entity.Id;
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            var course = await _controlNotasDbContext.Courses.SingleOrDefaultAsync(b=>b.Id == courseId);

            if (course == null) return;

            _controlNotasDbContext.Courses.Remove(course);

            await _controlNotasDbContext.SaveChangesAsync();
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            var entity = await _controlNotasDbContext.Courses
            .SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            var mapper = _mappingConfiguration.CreateMapper();
            return mapper.Map<Course>(entity);
        }

        public async Task<PagedResults<Course>> GetCoursesAsync(PagingOptions pagingOptions, SortOptions<Course, CourseEntity> sortOptions, SearchOptions<Course, CourseEntity> searchOptions)
        {
            IQueryable<CourseEntity> query = _controlNotasDbContext.Courses;
            query = searchOptions.Apply(query);
            query = sortOptions.Apply(query);

            int size = await query.CountAsync();

            var items = await query
                .Skip(pagingOptions.Offset.Value)
                .Take(pagingOptions.Limit.Value)
                .ProjectTo<Course>(_mappingConfiguration)
                .ToArrayAsync();

            var response = new PagedResults<Course>()
            {
                Items = items,
                TotalSize = size
            };

            return response;
        }
    }
}
