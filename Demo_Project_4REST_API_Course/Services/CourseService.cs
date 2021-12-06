using AutoMapper;
using Demo_Project_4REST_API_Course.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Demo_Project_4REST_API_Course.Services
{
    public class CourseService : ICourseService
    {
        private readonly ControlNotasDbContext _controlNotasDbContext;
        private readonly IMapper mapper;

        public CourseService(ControlNotasDbContext controlNotasDbContext, IMapper mapper)
        {
            _controlNotasDbContext = controlNotasDbContext;
            this.mapper = mapper;
        }
        public async Task<Course> GetCourseAsync(int id)
        {
            var entity = await _controlNotasDbContext.Courses
            .SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return mapper.Map<Course>(entity);
        }
    }
}
