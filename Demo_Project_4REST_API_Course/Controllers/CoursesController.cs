using Demo_Project_4REST_API_Course.Models;
using Demo_Project_4REST_API_Course.Services;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet(Name = nameof(GetCourses))]
        public IActionResult GetCourses()
        {
            var reponse = new
            {
                href = Url.Link(nameof(GetCourses), null)
            };

            return Ok(reponse);
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
