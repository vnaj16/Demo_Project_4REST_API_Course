using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo_Project_4REST_API_Course.Models;
using Microsoft.EntityFrameworkCore;
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
