using Demo_Project_4REST_API_Course.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo_Project_4REST_API_Course.Services
{
    public interface ICourseService
    {
        Task<PagedResults<Course>> GetCoursesAsync(PagingOptions pagingOptions, SortOptions<Course, CourseEntity> sortOptions, SearchOptions<Course, CourseEntity> searchOptions);
        Task<Course> GetCourseAsync(int id);

        Task<int> CreateCourseAsync(CourseForm courseForm);

        Task DeleteCourseAsync(int courseId);
    }
}
