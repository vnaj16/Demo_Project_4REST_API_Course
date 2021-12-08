using Demo_Project_4REST_API_Course.Models;
using Demo_Project_4REST_API_Course.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Project_4REST_API_Course.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    [ApiVersion("1.0")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet(Name = nameof(GetAllCourses))]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Collection<Course>>> GetAllCourses([FromQuery] PagingOptions pagingOptions= null)
        {
            var courses = await _courseService.GetCoursesAsync(pagingOptions);

            var collection = new PagedCollection<Course>
            {
                Self = Link.ToCollection(nameof(GetAllCourses)),
                Value = courses.Items.ToArray(),
                Size = courses.TotalSize,
                Offset = pagingOptions.Offset.Value,
                Limit = pagingOptions.Limit.Value
            };

            return collection;
        }

        [HttpGet("{courseId}", Name = nameof(GetcourseById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Course>> GetcourseById(int courseId)
        {
            var course = await _courseService.GetCourseAsync(courseId);
            if (course == null) return NotFound();
            return Ok(course);
        }
    }
}
