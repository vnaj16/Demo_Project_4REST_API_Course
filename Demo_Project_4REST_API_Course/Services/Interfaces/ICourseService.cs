using Demo_Project_4REST_API_Course.Models;
using System.Threading.Tasks;

namespace Demo_Project_4REST_API_Course.Services
{
    public interface ICourseService
    {
        Task<Course> GetCourseAsync(int id);
    }
}
