using Demo_Project_4REST_API_Course.Models;
using Demo_Project_4REST_API_Course.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        private readonly PagingOptions _defaultPagingOptions;
        public CoursesController(ICourseService courseService, IOptions<PagingOptions> defaultPagingOptions)
        {
            _courseService = courseService;
            _defaultPagingOptions = defaultPagingOptions.Value;
        }

        [HttpGet(Name = nameof(GetAllCourses))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Collection<Course>>> GetAllCourses([FromQuery] PagingOptions pagingOptions= null)
        {
            pagingOptions.Offset = pagingOptions.Offset ?? _defaultPagingOptions.Offset;
            pagingOptions.Limit = pagingOptions.Limit ?? _defaultPagingOptions.Limit;

            var courses = await _courseService.GetCoursesAsync(pagingOptions);

            var collection = PagedCollection<Course>.Create(
                Link.ToCollection(nameof(GetAllCourses)),
                courses.Items.ToArray(),
                courses.TotalSize,
                pagingOptions);

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
